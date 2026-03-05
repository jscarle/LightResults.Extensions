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
