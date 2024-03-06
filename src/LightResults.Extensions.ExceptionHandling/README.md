[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

# LightResults Extensions

Extensions for [LightResults](https://github.com/jscarle/LightResults), an extremely light and modern Operation Result Pattern library for .NET.

[![main](https://img.shields.io/github/actions/workflow/status/jscarle/LightResults.Extensions/main.yml?logo=github)](https://github.com/jscarle/LightResults.Extensions)

## ExceptionHandling

Provides extension methods for exception handling using LightResults.

[![nuget](https://img.shields.io/nuget/v/LightResults.Extensions.ExceptionHandling)](https://www.nuget.org/packages/LightResults.Extensions.ExceptionHandling)
[![downloads](https://img.shields.io/nuget/dt/LightResults.Extensions.ExceptionHandling)](https://www.nuget.org/packages/LightResults.Extensions.ExceptionHandling)

## Documentation

Make sure to [read the docs](https://jscarle.github.io/LightResults.Extensions/) for the full API.

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

### Using the Try method with methods

Although extension methods for `Action` or `Func` cannot be attached to ordinary methods, the compiler will
automatically cast ordinary methods to `Action` or `Func` if only the method name is manually passed as the
argument to the extension method.

There are two ways this can be achieved, both of which are explained below.

#### Using the static class name

```csharp
using LightResults.Extensions.ExceptionHandling;

public class OrdinaryClass
{
    public void OrdinaryMethod() { }
    public void TryOrdinaryMethod()
    {
        var result = ExceptionHandler.Try(OrdinaryMethod);
        if (result.IsSuccess)
        {
            // Do something
        }
    }
    
    public void OrdinaryMethodWithArguments(int arg1, int arg2) { }
    public void TryOrdinaryMethodWithArguments()
    {
        var result = ExceptionHandler.Try(OrdinaryMethodWithArguments, 1, 2);
        if (result.IsSuccess)
        {
            // Do something
        }
    }

    public int OrdinaryMethodWithReturn() { return 0; }
    public void TryOrdinaryMethodWithReturn()
    {
        var result = ExceptionHandler.Try(OrdinaryMethodWithReturn);
        if (result.IsSuccess)
        {
            var value = result.Value;
            // Do something
        }
    }

    public int OrdinaryMethodWithReturnAndArguments(int arg1, int arg2) { return arg1 + arg2; }
    public void TryOrdinaryMethodWithReturnAndArguments()
    {
        var result = ExceptionHandler.Try(OrdinaryMethodWithReturnAndArguments, 1, 2);
        if (result.IsSuccess)
        {
            var value = result.Value;
            // Do something
        }
    }
}
```

#### Declaring a `using static` statement

```csharp
using static LightResults.Extensions.ExceptionHandling.ExceptionHandler;

public class OrdinaryClass
{
    public void OrdinaryMethod() { }
    public void TryOrdinaryMethod()
    {
        var result = Try(OrdinaryMethod);
        if (result.IsSuccess)
        {
            // Do something
        }
    }
    
    public void OrdinaryMethodWithArguments(int arg1, int arg2) { }
    public void TryOrdinaryMethodWithArguments()
    {
        var result = Try(OrdinaryMethodWithArguments, 1, 2);
        if (result.IsSuccess)
        {
            // Do something
        }
    }

    public int OrdinaryMethodWithReturn() { return 0; }
    public void TryOrdinaryMethodWithReturn()
    {
        var result = Try(OrdinaryMethodWithReturn);
        if (result.IsSuccess)
        {
            var value = result.Value;
            // Do something
        }
    }

    public int OrdinaryMethodWithReturnAndArguments(int arg1, int arg2) { return arg1 + arg2; }
    public void TryOrdinaryMethodWithReturnAndArguments()
    {
        var result = Try(OrdinaryMethodWithReturnAndArguments, 1, 2);
        if (result.IsSuccess)
        {
            var value = result.Value;
            // Do something
        }
    }
}
```

### Getting the `Exception`

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
