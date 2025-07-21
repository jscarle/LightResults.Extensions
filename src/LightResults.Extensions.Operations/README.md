[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

# LightResults Extensions

Extensions for [LightResults](https://github.com/jscarle/LightResults), an extremely light and modern Operation Result Pattern library for .NET.

[![main](https://img.shields.io/github/actions/workflow/status/jscarle/LightResults.Extensions/publish.yml?logo=github)](https://github.com/jscarle/LightResults.Extensions)

## Operations

Provides additional operations for working with LightResults.

[![nuget](https://img.shields.io/nuget/v/LightResults.Extensions.Operations)](https://www.nuget.org/packages/LightResults.Extensions.Operations)
[![downloads](https://img.shields.io/nuget/dt/LightResults.Extensions.Operations)](https://www.nuget.org/packages/LightResults.Extensions.Operations)

## Documentation

Make sure to [read the docs](https://jscarle.github.io/LightResults.Extensions/) for the full API.

### Collect method

The `Collect` method allows you to combine multiple results into a single result.

#### Basic usage

```csharp
var results = new List<Result>
{
    Result.Success(),
    Result.Success(),
    Result.Failure("Error message")
};

var combinedResult = results.Collect();
// combinedResult will be a failed result containing all errors from the input results
```

#### With successful results

```csharp
var results = new List<Result>
{
    Result.Success(),
    Result.Success(),
    Result.Success()
};

var combinedResult = results.Collect();
// combinedResult will be a successful result since all input results were successful
```

The `Collect` method returns:
- A successful result if all input results were successful
- A failed result containing all errors from the input results if any were failed

This is particularly useful when you need to validate multiple operations and want to collect all failures rather than stopping at the first one. 