[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

# LightResults Extensions

Extensions for [LightResults](https://github.com/jscarle/LightResults), an extremely light and modern Operation Result Pattern library for .NET.

[![main](https://img.shields.io/github/actions/workflow/status/jscarle/LightResults.Extensions/publish.yml?logo=github)](https://github.com/jscarle/LightResults.Extensions)

## Json

Provides System.Text.Json converters for serializing `Result` and `Result<TValue>` types to JSON.

[![nuget](https://img.shields.io/nuget/v/LightResults.Extensions.Json)](https://www.nuget.org/packages/LightResults.Extensions.Json)
[![downloads](https://img.shields.io/nuget/dt/LightResults.Extensions.Json)](https://www.nuget.org/packages/LightResults.Extensions.Json)

## Documentation

Make sure to [read the docs](https://jscarle.github.io/LightResults.Extensions/) for the full API.

### JSON Converters

This package provides JSON converters for serializing `Result` and `Result<TValue>` types using System.Text.Json. The converters support serialization only, as Result types cannot be reliably deserialized without losing data.

**Provided Converters:**
- **`ResultJsonConverter`** - Serializes `Result` (non-generic) types
- **`ResultJsonConverter<TValue>`** - Serializes `Result<TValue>` types  
- **`ResultJsonConverterFactory`** - Factory that automatically selects the appropriate converter

### Setup

Add the converter factory to your JsonSerializerOptions:

```csharp
using System.Text.Json;
using LightResults.Extensions.Json;

var options = new JsonSerializerOptions
{
    Converters =
    {
        new ResultJsonConverterFactory()
    }
};
```

For ASP.NET Core applications, configure in `Program.cs`:

```csharp
using LightResults.Extensions.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new ResultJsonConverterFactory());
});

var app = builder.Build();
```

### Usage Examples

#### Serializing Success Results

```csharp
using System.Text.Json;
using LightResults.Extensions.Json;

var options = new JsonSerializerOptions
{
    Converters = { new ResultJsonConverterFactory() }
};

// Success without value
var result = Result.Success();
var json = JsonSerializer.Serialize(result, options);
// Output: {"IsSuccess":true}

// Success with value
var resultWithValue = Result.Success(42);
var jsonWithValue = JsonSerializer.Serialize(resultWithValue, options);
// Output: {"IsSuccess":true,"Value":42}

// Success with complex object
var user = new { Id = 1, Name = "John Doe" };
var userResult = Result.Success(user);
var userJson = JsonSerializer.Serialize(userResult, options);
// Output: {"IsSuccess":true,"Value":{"Id":1,"Name":"John Doe"}}
```

#### Serializing Failure Results

```csharp
// Simple failure
var failureResult = Result.Failure("Something went wrong");
var failureJson = JsonSerializer.Serialize(failureResult, options);
// Output: {"IsSuccess":false,"Errors":[{"$type":"LightResults.Error","Message":"Something went wrong"}]}

// Failure with metadata
var metadata = new Dictionary<string, object?> { { "ErrorCode", 404 } };
var failureWithMetadata = Result.Failure("Not found", metadata);
var metadataJson = JsonSerializer.Serialize(failureWithMetadata, options);
// Output: {"IsSuccess":false,"Errors":[{"$type":"LightResults.Error","Message":"Not found","Metadata":{"ErrorCode":{"$type":"System.Int32","Value":404}}}]}

// Failure with exception
try
{
    throw new InvalidOperationException("Invalid operation");
}
catch (Exception ex)
{
    var exceptionResult = Result.Failure("Operation failed", ex);
    var exceptionJson = JsonSerializer.Serialize(exceptionResult, options);
    // Output includes exception details in metadata
}
```

#### API Responses

Perfect for API responses that need to communicate both success/failure state and associated data:

```csharp
// API Controller example
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var result = await userService.GetUserAsync(id);
        
        // Result will be automatically serialized with proper JSON structure
        return result.IsSuccess() ? Ok(result) : BadRequest(result);
    }
}

// Success response JSON:
// {"IsSuccess":true,"Value":{"Id":1,"Name":"John Doe","Email":"john@example.com"}}

// Failure response JSON:
// {"IsSuccess":false,"Errors":[{"$type":"LightResults.Error","Message":"User not found"}]}
```

#### Working with Collections

```csharp
// Collection of results
var results = new[]
{
    Result.Success("First"),
    Result.Failure("Second failed"),
    Result.Success("Third")
};

var collectionJson = JsonSerializer.Serialize(results, options);
// Each result in the array will be properly serialized

// Result containing a collection
var items = new[] { "item1", "item2", "item3" };
var collectionResult = Result.Success(items);
var json = JsonSerializer.Serialize(collectionResult, options);
// Output: {"IsSuccess":true,"Value":["item1","item2","item3"]}
```

### JSON Structure

The converters produce a consistent JSON structure:

**Success Result:**
```json
{
  "IsSuccess": true,
  "Value": <serialized_value> // Only present for Result<TValue>
}
```

**Failure Result:**
```json
{
  "IsSuccess": false,
  "Errors": [
    {
      "$type": "LightResults.Error",
      "Message": "Error message",
      "Metadata": {
        "Key": {
          "$type": "System.String",
          "Value": "metadata_value"
        }
      }
    }
  ]
}
```

**Exception Handling:**
When an exception is stored in error metadata, it's serialized with its message and stack trace:
```json
{
  "$type": "System.InvalidOperationException",
  "Message": "Operation is not valid due to the current state of the object.",
  "StackTrace": "stack_trace_here"
}
```

### Limitations

- **Deserialization not supported**: The converters only support serialization. Result types cannot be reliably deserialized without potential data loss
- **Type information**: The JSON includes type discriminators (`$type`) to preserve type information during serialization
- **Metadata serialization**: Complex objects in metadata are serialized with their full type information
