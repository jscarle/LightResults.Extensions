[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

# LightResults Extensions

Extensions for [LightResults](https://github.com/jscarle/LightResults), an extremely light and modern Operation Result Pattern library for .NET.

[![main](https://img.shields.io/github/actions/workflow/status/jscarle/LightResults.Extensions/main.yml?logo=github)](https://github.com/jscarle/LightResults.Extensions)

## EntityFrameworkCore

Provides a DbContext that wraps context operations using LightResults.

[![nuget](https://img.shields.io/nuget/v/LightResults.Extensions.EntityFrameworkCore)](https://www.nuget.org/packages/LightResults.Extensions.EntityFrameworkCore)
[![downloads](https://img.shields.io/nuget/dt/LightResults.Extensions.EntityFrameworkCore)](https://www.nuget.org/packages/LightResults.Extensions.EntityFrameworkCore)

## Documentation

Make sure to [read the docs](https://jscarle.github.io/LightResults.Extensions/) for the full API.

### New method definitions

The following methods are wrapped internally with a `try { } catch { }` block and have their signatures
updated to result a `Result`. If an exception occurs, a failed result will be returned and the `Exception`
will be added to the result as metadata.

- `AddAsync()`
- `AddAsync<TEntity>()`
- `AddRangeAsync()`
- `Find()`
- `Find<TEntity>()`
- `FindAsync()`
- `FindAsync<TEntity>()`
- `SaveChanges()`
- `SaveChangesAsync()`

#### Getting the `Exception`

```csharp
var result = dbContext.SaveChangesAsync();
if (result.IsFailed)
{
    var ex = (Exception)result.Error.Metadata["Exception"];
    // Do something with the base exception type or...
    
    if (ex is DbUpdateException dbUpdateException)
    {
        // Do something with a specific exception type
    }
}
```
