<#
Saves clipboard or piped input to Copilot_Chat with a timestamped filename,
commits the file, and pushes to origin/main.

Usage:
  # copy chat text to clipboard then run:
  .\tools\save_chat_transcript.ps1

  # or pipe content:
  Get-Content .\some_chat.txt | .\tools\save_chat_transcript.ps1
#>

param(
    [string]$Folder = "Copilot_Chat",
    [string]$Remote = "origin",
    [string]$Branch = "main"
)

function Get-InputContent {
    $stdin = @()
    while ($false -eq $Host.UI.RawUI.KeyAvailable -and -not $input.EndOfStream) {
        $line = $input.ReadLine()
        if ($null -eq $line) { break }
        $stdin += $line
    }
    if ($stdin.Count -gt 0) { return ($stdin -join "`n") }

    # fallback to clipboard
    try {
        return Get-Clipboard -Raw -ErrorAction Stop
    } catch {
        return $null
    }
}

$content = Get-InputContent
if (-not $content) {
    Write-Error "No content found in stdin or clipboard. Copy the chat text to the clipboard or pipe content into the script."
    exit 1
}

$timestamp = Get-Date -Format "yyyy-MM-dd_HH-mm-ss"
if (-not (Test-Path $Folder)) { New-Item -ItemType Directory -Path $Folder | Out-Null }
$filename = Join-Path $Folder ("chat_transcript_$timestamp.md")
Set-Content -Path $filename -Value $content -Encoding UTF8

Write-Output "Saved transcript to $filename"

# Attempt to commit and push
if (Get-Command git -ErrorAction SilentlyContinue) {
    try {
        git add $filename
        git commit -m "chore(docs): add chat transcript $timestamp" | Out-Null
        git push $Remote $Branch
        Write-Output "Committed and pushed $filename to $Remote/$Branch"
    } catch {
        Write-Warning "Could not commit/push automatically: $_. You can commit and push $filename manually."
    }
} else {
    Write-Warning "Git is not available in PATH. Saved the file locally at $filename."
}
