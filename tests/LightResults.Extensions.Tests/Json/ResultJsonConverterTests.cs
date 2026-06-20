using System.Text.Json;
using LightResults.Extensions.Json;
using System.Text.Json.Serialization;
using Shouldly;
using Xunit;

namespace LightResults.Extensions.Tests.Json;

public sealed class ResultJsonConverterTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters =
        {
            new ResultJsonConverterFactory(),
        },
    };

    [Fact]
    public void SuccessResult()
    {
        // Arrange
        var result = Result.Success();

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe("{\"IsSuccess\":true}");
    }

    [Fact]
    public void SuccessWithValueResult()
    {
        // Arrange
        var result = Result.Success(42);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe("{\"IsSuccess\":true,\"Value\":42}");
    }

    [Fact]
    public void FailedResultWithSingleError()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        var result = Result.Failure(errorMessage);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe("{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\"}]}");
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMetadata()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        IReadOnlyDictionary<string, object?> metadata = new Dictionary<string, object?>
        {
            { "Key", 0 },
        };
        var result = Result.Failure(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Key\":{\"$type\":\"System.Int32\",\"Value\":0}}}]}"
        );
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMetadataWithException()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        var exception = new InvalidOperationException();
        IReadOnlyDictionary<string, object?> metadata = new Dictionary<string, object?>
        {
            { "Exception", exception },
        };
        var result = Result.Failure(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Exception\":{\"$type\":\"System.InvalidOperationException\",\"Message\":\"Operation is not valid due to the current state of the object.\",\"StackTrace\":null}}}]}"
        );
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMetadataWithExceptionAndInnerException()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        var exception = new InvalidProgramException("Invalid program!", new InvalidOperationException());
        IReadOnlyDictionary<string, object?> metadata = new Dictionary<string, object?>
        {
            { "Exception", exception },
        };
        var result = Result.Failure(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Exception\":{\"$type\":\"System.InvalidProgramException\",\"Message\":\"Invalid program!\",\"StackTrace\":null,\"InnerException\":{\"$type\":\"System.InvalidOperationException\",\"Message\":\"Operation is not valid due to the current state of the object.\",\"StackTrace\":null}}}}]}"
        );
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMultipleMetadata()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        IReadOnlyDictionary<string, object?> metadata = new Dictionary<string, object?>
        {
            { "Key", 0 },
            { "OtherKey", 1 },
        };
        var result = Result.Failure(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Key\":{\"$type\":\"System.Int32\",\"Value\":0},\"OtherKey\":{\"$type\":\"System.Int32\",\"Value\":1}}}]}"
        );
    }

    [Fact]
    public void FailedResultWithMultipleErrors()
    {
        // Arrange
        var errors = new List<IError>
        {
            new Error("Error 1"),
            new Error("Error 2"),
        };
        var result = Result.Failure(errors);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Error 1\"},{\"$type\":\"LightResults.Error\",\"Message\":\"Error 2\"}]}"
        );
    }

    [Fact]
    public void SuccessWithComplexValueResult_ShouldUseSerializerOptions()
    {
        // Arrange
        var result = Result.Success(new Payload("Ada", new Secret("hidden")));
        var options = CreateCustomOptions();

        // Act
        var json = JsonSerializer.Serialize(result, options);

        // Assert
        json.ShouldBe("{\"IsSuccess\":true,\"Value\":{\"firstName\":\"Ada\",\"secret\":\"redacted\"}}");
    }

    [Fact]
    public void FailedResultWithComplexMetadata_ShouldUseSerializerOptions()
    {
        // Arrange
        var error = new Error("Error 1", ("Payload", new Payload("Ada", new Secret("hidden"))));
        var result = Result.Failure(error);
        var options = CreateCustomOptions();

        // Act
        var json = JsonSerializer.Serialize(result, options);

        // Assert
        using var document = JsonDocument.Parse(json);
        var payloadValue = document.RootElement
            .GetProperty("Errors")[0]
            .GetProperty("Metadata")
            .GetProperty("Payload")
            .GetProperty("Value");

        payloadValue.GetProperty("firstName").GetString().ShouldBe("Ada");
        payloadValue.GetProperty("secret").GetString().ShouldBe("redacted");
    }

    [Fact]
    public void SuccessWithTimeOnlyValueResult_ShouldPreserveFractionalSeconds()
    {
        // Arrange
        var time = new TimeOnly(12, 34, 56).Add(TimeSpan.FromTicks(1234567));
        var result = Result.Success(time);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe("{\"IsSuccess\":true,\"Value\":\"12:34:56.1234567\"}");
    }

    [Fact]
    public void SuccessWithNamedFloatingPointLiteral_ShouldUseNumberHandlingOptions()
    {
        // Arrange
        var result = Result.Success(double.NaN);
        var options = CreateNamedFloatingPointOptions();

        // Act
        var json = JsonSerializer.Serialize(result, options);

        // Assert
        json.ShouldBe("{\"IsSuccess\":true,\"Value\":\"NaN\"}");
    }

    [Fact]
    public void FailedResultWithTimeOnlyMetadata_ShouldPreserveFractionalSeconds()
    {
        // Arrange
        var time = new TimeOnly(12, 34, 56).Add(TimeSpan.FromTicks(1234567));
        var result = Result.Failure(new Error("Error 1", ("Time", time)));

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Error 1\",\"Metadata\":{\"Time\":{\"$type\":\"System.TimeOnly\",\"Value\":\"12:34:56.1234567\"}}}]}"
        );
    }

    [Fact]
    public void FailedResultWithNamedFloatingPointMetadata_ShouldUseNumberHandlingOptions()
    {
        // Arrange
        var result = Result.Failure(new Error("Error 1", ("Value", double.NaN)));
        var options = CreateNamedFloatingPointOptions();

        // Act
        var json = JsonSerializer.Serialize(result, options);

        // Assert
        json.ShouldBe(
            "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Error 1\",\"Metadata\":{\"Value\":{\"$type\":\"System.Double\",\"Value\":\"NaN\"}}}]}"
        );
    }

    private static JsonSerializerOptions CreateCustomOptions()
    {
        return new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new ResultJsonConverterFactory(),
                new SecretConverter(),
            },
        };
    }

    private static JsonSerializerOptions CreateNamedFloatingPointOptions()
    {
        return new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
            Converters =
            {
                new ResultJsonConverterFactory(),
            },
        };
    }

    private sealed record Payload(string FirstName, Secret Secret);

    private sealed record Secret(string Value);

    private sealed class SecretConverter : JsonConverter<Secret>
    {
        public override Secret Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }

        public override void Write(Utf8JsonWriter writer, Secret value, JsonSerializerOptions options)
        {
            writer.WriteStringValue("redacted");
        }
    }
}
