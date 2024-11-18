using System.Text.Json;
using FluentAssertions;
using LightResults.Extensions.Json;
using Xunit;

namespace LightResults.Extensions.Tests;

public sealed class ResultJsonConverterTests
{
    private static readonly JsonSerializerOptions Options = new() { Converters = { new ResultJsonConverterFactory() } };

    [Fact]
    public void SuccessResult()
    {
        // Arrange
        var result = Result.Ok();

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should().Be("{\"IsSuccess\":true}");
    }

    [Fact]
    public void SuccessWithValueResult()
    {
        // Arrange
        var result = Result.Ok(42);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should().Be("{\"IsSuccess\":true,\"Value\":42}");
    }

    [Fact]
    public void SuccessWithObjectValueResult()
    {
        // Arrange
        var result = Result.Ok(new { Id = 1, Name = "Test" });

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should().Be("{\"IsSuccess\":true,\"Value\":{\"Id\":1,\"Name\":\"Test\"}}");
    }

    [Fact]
    public void FailedResultWithSingleError()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        var result = Result.Fail(errorMessage);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should().Be("{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\"}]}");
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMetadata()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        IDictionary<string, object> metadata = new Dictionary<string, object> { { "Key", 0 } };
        var result = Result.Fail(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should()
            .Be(
                "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Key\":{\"$type\":\"System.Int32\",\"Value\":0}}}]}"
            );
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMetadataWithException()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        var exception = new InvalidOperationException();
        IDictionary<string, object> metadata = new Dictionary<string, object> { { "Exception", exception } };
        var result = Result.Fail(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should()
            .Be(
                "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Exception\":{\"$type\":\"System.InvalidOperationException\",\"Message\":\"Operation is not valid due to the current state of the object.\",\"StackTrace\":null}}}]}"
            );
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMetadataWithExceptionAndInnerException()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        var exception = new InvalidProgramException("Invalid program!", new InvalidOperationException());
        IDictionary<string, object> metadata = new Dictionary<string, object> { { "Exception", exception } };
        var result = Result.Fail(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should()
            .Be(
                "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Exception\":{\"$type\":\"System.InvalidProgramException\",\"Message\":\"Invalid program!\",\"StackTrace\":null,\"InnerException\":{\"$type\":\"System.InvalidOperationException\",\"Message\":\"Operation is not valid due to the current state of the object.\",\"StackTrace\":null}}}}]}"
            );
    }

    [Fact]
    public void FailedResultWithSingleErrorAndMultipleMetadata()
    {
        // Arrange
        const string errorMessage = "Sample error message";
        IDictionary<string, object> metadata = new Dictionary<string, object> { { "Key", 0 }, { "OtherKey", 1 } };
        var result = Result.Fail(errorMessage, metadata);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should()
            .Be(
                "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Sample error message\",\"Metadata\":{\"Key\":{\"$type\":\"System.Int32\",\"Value\":0},\"OtherKey\":{\"$type\":\"System.Int32\",\"Value\":1}}}]}"
            );
    }

    [Fact]
    public void FailedResultWithMultipleErrors()
    {
        // Arrange
        var errors = new List<IError> { new Error("Error 1"), new Error("Error 2") };
        var result = Result.Fail(errors);

        // Act
        var json = JsonSerializer.Serialize(result, Options);

        // Assert
        json.Should()
            .Be(
                "{\"IsSuccess\":false,\"Errors\":[{\"$type\":\"LightResults.Error\",\"Message\":\"Error 1\"},{\"$type\":\"LightResults.Error\",\"Message\":\"Error 2\"}]}"
            );
    }
}
