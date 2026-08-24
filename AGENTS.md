# Guidelines for AI Contributors

This repository contains high-performance C# libraries that extend the [LightResults](https://github.com/jscarle/LightResults) result pattern. The packages here are distributed to millions of consumers and many APIs are executed in extremely hot paths. All contributions must maintain very high quality and performance.

## Repository layout

- **src** – Contains five projects:
  - `LightResults.Extensions.ExceptionHandling`
  - `LightResults.Extensions.EntityFrameworkCore`
  - `LightResults.Extensions.Json`
  - `LightResults.Extensions.OpenAI`
  - `LightResults.Extensions.Operations`
- **tests** – xUnit test project located in `tests/LightResults.Extensions.Tests`.
- **tools** – Benchmark projects under `tools/Benchmarks`.

## Building and testing

Always verify your changes by running the same steps as CI:

```bash
# Restore and build all projects
 dotnet restore
 dotnet build --configuration Release --no-restore

# Run tests (targeting .NET 10)
 dotnet test --configuration Release --no-build --verbosity normal --framework net10.0
```

The solution targets multiple frameworks (net8.0–net10.0). Make sure all target frameworks compile.

## Coding style

- Follow `.editorconfig` – UTF‑8 encoding, LF line endings, 4‑space indentation, maximum line length 160 and a final newline.
- Use `var` for local variables when the type is obvious.
- Keep braces for loops and multi-statement blocks. Single‑line `if` statements may omit braces.
- Null checks should prefer `ArgumentNullException.ThrowIfNull` when available.
- Public APIs must include XML documentation comments (`///`).
- Extension methods should be declared in static classes.
- Avoid LINQ in hot paths; prefer explicit loops to minimize allocations.
- Prefer `List<T>?` variables initialized to `null` and create them only when needed to reduce allocations.
- Use conditional compilation (`#if`) when a feature requires a specific target framework.

## Testing style

- Tests use **xUnit** with **Shouldly** for assertions. Follow existing patterns in `tests/LightResults.Extensions.Tests`.
- Keep tests deterministic and avoid unnecessary allocations.
- Add tests for every new feature or bug fix.

## Performance considerations

Many APIs are used millions of times per second. Pay attention to:

- Minimizing heap allocations and virtual calls.
- Avoiding exceptions for control flow. Instead, return `Result` failures.
- Using `readonly struct` or `in` parameters when appropriate.
- Avoiding boxing by using generic overloads when needed.
- Never run the benchmarks in `tools/Benchmarks`.

## Commit guidelines

- Keep commit messages concise: a short summary in the imperative mood.
- Run tests before committing. Only commits with a clean working tree and passing tests should be submitted.

Following these guidelines will help maintain the quality and performance standards expected from this repository.

## Release Intent, Versioning, and Workflow

Treat explicit release requests—such as “Mint a new release,” “Release this,” “Publish this as a new release,” “Create a new release,” or any clear equivalent—as authorization to carry out LightResults.Extensions' full release workflow, including committing, pushing, tagging, and publishing as needed.

If the user has not clearly requested a release, or if the appropriate change category or package scope cannot be determined confidently, ask for clarification **before** committing, pushing, creating a tag, or publishing a release.

Only change package, assembly, and file versions when the user has clearly requested that a release be published. Do not bump versions during ordinary implementation, refactoring, bug-fixing, performance work, dependency updates, testing, commits, pushes, or pull-request preparation unless those actions are part of an explicitly requested release.

Version each affected extension package independently using these repository-specific rules:

- Minor, backward-compatible changes increment the affected package's patch component. Example: `10.0.8` → `10.0.9`.
- Moderate or breaking changes increment the affected package's middle component and reset its patch. Example: `10.0.8` → `10.1.0`.
- Increment an affected package's major component and reset the other components only when its newest supported .NET version changes. Example: `10.0.8` → `11.0.0`.
- Breaking changes alone do not justify a major-version increment in this repository. If multiple categories apply to a package, use the highest applicable category.

The packable projects under `src/` are `LightResults.Extensions.ExceptionHandling`, `LightResults.Extensions.EntityFrameworkCore`, `LightResults.Extensions.Json`, `LightResults.Extensions.Operations`, and `LightResults.Extensions.OpenAI`. Update only the affected projects, using three components for `Version` and matching four-component `AssemblyVersion` and `FileVersion` values.

Use a lightweight scoped tag such as `OpenAI-v10.0.9`, `Json-v10.0.4`, `Operations-v10.0.3`, `ExceptionHandling-v10.0.4`, or `EntityFrameworkCore-v10.0.3` when releasing one package. Use a lightweight `vX.Y.Z` tag only for a coherent repository-wide or multi-package release. If the package scope does not map clearly to an established tag convention, ask before creating a tag. Historical tag types are mixed, but new release tags must be lightweight.

A clear release request authorizes this complete workflow:

1. Inspect the worktree, current branch, `origin`, `develop`, every package version, recent commits, pull requests, tags, and releases before editing metadata.
2. Identify the packages included in the release, determine each next version, update only their project version properties, and verify that the intended tag and release do not already exist.
3. Validate the release-scoped changes using the repository's normal restore, Release build, test, and pack commands across all supported target frameworks without running benchmarks.
4. Commit all release-scoped changes on the reusable `feature/work` branch using a concise past-tense sentence ending in a period, then push `feature/work`.
5. Open a ready pull request from `feature/work` to `develop` using recent title and body conventions, enable squash auto-merge, and monitor checks and review state.
6. Fix and push any issue that prevents the pull request from merging, then wait until it is merged.
7. Fast-forward local `develop` from `origin/develop` and reset local `feature/work` to that latest `develop` commit. The remote feature branch may be deleted automatically after merge.
8. Create the selected lightweight tag on the latest `develop` commit and push that tag to `origin`.
9. Publish a non-draft GitHub release named `<tag> - Description`, using release notes scoped to the packages being published.
10. Monitor the release-triggered `Publish` workflow until every newly versioned NuGet package is published successfully; unchanged package versions are expected to be skipped as duplicates.

Do not require separate confirmation for each Git or GitHub step after an unambiguous release command. Report the package versions, pull request, merge commit, tag, GitHub release URL, and NuGet publishing result when complete.
