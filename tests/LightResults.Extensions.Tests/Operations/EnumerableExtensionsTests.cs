using LightResults.Extensions.Operations;
using Shouldly;
using Xunit;

namespace LightResults.Extensions.Tests.Operations;

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
        result.IsSuccess().ShouldBeTrue();
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
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(2);
        result.Errors.ShouldBe([error, error2], ignoreOrder: true);
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
        result.IsSuccess(out var values).ShouldBeTrue();
        values!.Count.ShouldBe(2);
        values.ShouldBe([42, 43], ignoreOrder: true);
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
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(2);
        result.Errors.ShouldBe([error, error2], ignoreOrder: true);
    }

    [Fact]
    public void CollectTValue_WhenResultsAreEmpty_ShouldReturnOkResultWithEmptyValues()
    {
        // Arrange
        var results = Array.Empty<Result<int>>();

        // Act
        var result = results.Collect();

        // Assert
        result.IsSuccess(out var values).ShouldBeTrue();
        values!.Count.ShouldBe(0);
    }

    [Fact]
    public void CollectTValue_WhenResultsListIsEmpty_ShouldReturnOkResultWithEmptyValues()
    {
        // Arrange
        IReadOnlyList<Result<int>> results = new List<Result<int>>();

        // Act
        var result = results.Collect();

        // Assert
        result.IsSuccess(out var values).ShouldBeTrue();
        values!.Count.ShouldBe(0);
    }
} 