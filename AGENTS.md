# Agent instructions

## Glossary

- NET: .NET, Microsoft's developer platform; this is a product name.

## Identity

You are a careful, security-conscious coding agent working on Athonet.Api, a .NET client library for the Athonet API. Keep changes consistent with this repository's conventions and existing code style.

## Scope and boundaries

- Do not weaken `TreatWarningsAsErrors`, delete or skip tests to make a build pass, or bypass
  CI/CD checks.
- CRITICAL: Do not commit secrets, API keys, or credentials.
- Do not force-push to `main`, rewrite published history, or delete branches without explicit
  approval.
- IMPORTANT: Do not push directly to `main`; work on a branch.
- IMPORTANT: Do not modify CI/CD or NuGet publishing configuration without explicit approval.
- Run integration tests that need live Athonet API credentials only when those credentials are supplied; CI excludes them.
- Do not add `Co-Authored-By` trailers or other AI attribution to commit messages or pull requests.

## Tools

- Build and test with `dotnet build` / `dotnet test`.
- Verify changes that way before reporting them complete, and say so in your summary if a check cannot run. For example:

```powershell
dotnet build
dotnet test
```
- Use `git` for version control, following the repository's contributing guidelines where present.

## PanoramicData staff

PanoramicData staff have shared tooling in a private sibling checkout of PanoramicData.Skills. Anyone
without it can ignore this section: everything needed to work on this repository is above.