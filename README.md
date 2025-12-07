# Oscar Solution — Local setup and debugging

This repository contains MAUI apps and libraries. VS Code launch and task configurations are provided in `.vscode` to run and debug the Windows targets.

Quick summary
- `/.vscode/launch.json` — launch configurations for Debug and Release (Windows) of `OscarAdmin` and `OscarView`.
- `/.vscode/tasks.json` — build tasks for Debug and Release for both apps.
- `.gitignore` — ignores build outputs and user files.

[![CI](https://github.com/GeoffTyrer/Oscar_Solution/actions/workflows/ci.yml/badge.svg)](https://github.com/GeoffTyrer/Oscar_Solution/actions)

How to use (Windows / PowerShell)

Build from the command line:
```powershell
dotnet build .\OscarAdmin_App\OscarAdmin.csproj /property:Configuration=Debug
dotnet build .\OscarView_App\OscarView.csproj /property:Configuration=Debug
```

Use the Run and Debug view in VS Code (Ctrl+Shift+D) and pick one of the configurations (e.g., `Launch OscarAdmin (Debug, Windows)`). Press F5 to build and start debugging.

Create a GitHub remote (recommended approach)

1. Install GitHub CLI: https://cli.github.com/ (if you don't already have it).
2. Authenticate: `gh auth login` and follow the prompts (choose HTTPS or SSH).
3. From the repo root run:
```powershell
gh repo create <your-github-username>/<repo-name> --public --source . --remote origin --push
```

Notes:
- If you prefer not to use `gh`, you can create an empty repo on GitHub via the website and then follow the instructions it shows to push your local `main` branch.
- I initialized this workspace with a local Git repo and made an initial commit. If you'd like, I can try to create the remote for you — you'll need to authenticate locally with `gh auth login` and then I can run the push command.

Continuous Integration

This repository includes a GitHub Actions workflow that builds the solution on Windows for pushes and pull requests to `main`. The workflow file is `.github/workflows/ci.yml`.

Artifacts

- Each workflow run uploads build outputs for both `Debug` and `Release` configurations as job artifacts. You can download them from the run details in the Actions tab (look for `build-Debug` and `build-Release`).

Badge

- The CI badge at the top shows the status of the `CI` workflow for the `main` branch.
