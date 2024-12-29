using FluentAssertions;
using LightResults.Extensions.Operations;
using Xunit;

namespace LightResults.Extensions.Tests;

public sealed class EnumerableExtensionsTests
{
    [Fact]
    public void Collect_WhenResultsAreSuccessful_ShouldReturnOkResult()
    {
        // Arrange
        var results = new[]
        {
            Result.Success(),
            Result.Success()
        };

        // Act
        var result = results.Collect();

        // Assert
        result.IsSuccess().Should().BeTrue();
    }

    [Fact]
    public void Collect_WhenResultsAreMixed_ShouldReturnFailedResult()
    {
        // Arrange
        var error = new Error("Error message");
        var error2 = new Error("Error message 2");
        var results = new[]
        {
            Result.Success(),
            Result.Failure(error),
            Result.Failure(error2)
        };

        // Act
        var result = results.Collect();

        // Assert
        result.IsSuccess().Should().BeFalse();
        result.Errors.Should().HaveCount(2).And.BeEquivalentTo([error, error2]);
    }

    [Fact]
    public void CollectTValue_WhenResultsAreSuccessful_ShouldReturnOkResultWithValues()
    {
        // Arrange
        var results = new[]
        {
            Result.Success(42),
            Result.Success(43)
        };

        // Act
        var result = results.Collect();

        // Assert
        result.IsSuccess(out var values).Should().BeTrue();
        values.Should().HaveCount(2).And.BeEquivalentTo([42, 43]);
    }

    [Fact]
    public void CollectTValue_WhenResultsAreMixed_ShouldReturnFailedResult()
    {
        // Arrange
        var error = new Error("Error message");
        var error2 = new Error("Error message 2");
        var results = new[]
        {
            Result.Success(42),
            Result.Failure<int>(error),
            Result.Failure<int>(error2)
        };

        // Act
        var result = results.Collect();

        // Assert
        result.IsSuccess().Should().BeFalse();
        result.Errors.Should().HaveCount(2).And.BeEquivalentTo([error, error2]);
    }
}
