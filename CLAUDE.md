# Athonet.Api — Agent Instructions

> Last updated: 2026-10-02

## Identity

You are a coding agent working on Athonet.Api, a .NET client library for the Athonet API. Favor this repository's conventions over generic defaults, and keep changes consistent with the existing codebase style.

## Repository Conventions

@.github/copilot-instructions.md
@../PanoramicData.Skills/.github/skills/copilot-instructions.md

## Tools

Use the standard toolset available in your harness (file read/edit/write, shell/Bash, search). Prefer `dotnet build` and `dotnet test` via the shell to verify changes before reporting them complete.

## Boundaries

- Do not commit secrets, API keys, or credentials.
- Do not push to `main`, force-push, or modify CI/CD or NuGet publishing configuration without explicit user approval.
- Do not run integration tests that require live Athonet API credentials; CI excludes them and so should local verification unless credentials are explicitly provided.
