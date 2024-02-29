[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

# LightResults.Extensions

Extensions for [LightResults](https://github.com/jscarle/LightResults), an extremely light and modern Operation Result Pattern library for .NET.

## LightResults.Extensions.ExceptionHandling

Provides extension methods for exception handling using LightResults.

### Try method

The `Try` method will wrap the execution of an `Action` or `Func` in a `try { } catch { }` block. If an
exception occurs, a failed result will be returned and the `Exception` will be added to the result as metadata.

#### With an `Action`

```csharp
var result = action.Try();
if (result.IsSuccess)
{
    // Do something
}
```

#### With an `Action` with arguments

```csharp
var result = action.Try(42);
if (result.IsSuccess)
{
    // Do something
}
```

#### With a `Func`

```csharp
var result = func.Try();
if (result.IsSuccess)
{
    var value = result.Value;
    // Do something
}
```

#### With a `Func` with arguments

```csharp
var result = func.Try(42);
if (result.IsSuccess)
{
    var value = result.Value;
    // Do something
}
```

#### Getting the `Exception`

```csharp
var result = action.Try();
if (result.IsFailed)
{
    var ex = (Exception)result.Error.Metadata["Exception"];
    // Do something with the base exception type or...
    
    if (ex is ArgumentNullException argumentNullException)
    {
        // Do something with a specific exception type
    }
}
```
