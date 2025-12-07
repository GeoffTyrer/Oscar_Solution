Copilot Chat Transcripts
=======================

This folder stores chat transcripts and summaries produced by the assistant.

How it works
- The assistant may create a transcript file here after a session summarising actions taken and important notes.
- To save a full raw transcript from your chat client, copy the chat text to the clipboard and run the helper script `tools\save_chat_transcript.ps1`.

Script usage
-------------
- From PowerShell, run:
  ```powershell
  .\tools\save_chat_transcript.ps1
  ```
  The script reads the clipboard and saves it to `Copilot_Chat` with a timestamped filename, then commits and pushes the file to `origin/main`.

Notes
- The script will attempt to commit and push using your local Git credentials. You must be authenticated to GitHub locally for the push to succeed.
- The assistant will not include secrets in transcripts. Do not paste passwords or tokens into transcripts.
