using Shouldly;
using LightResults.Extensions.ExceptionHandling;
using Xunit;

namespace LightResults.Extensions.Tests.ExceptionHandling;

public sealed class EnumerableExtensionsTests
{
    [Fact]
    public void AsEnumerableResult_ValidSequence_ShouldReturnAllItemsAsSuccessResults()
    {
        // Arrange
        var source = new[] { 1, 2, 3, 4, 5 };

        // Act
        var results = source.AsEnumerableResult().ToList();

        // Assert
        results.Count.ShouldBe(5);
        results.ShouldAllBe(r => r.IsSuccess());

        for (var i = 0; i < source.Length; i++)
        {
            results[i].IsSuccess(out var value).ShouldBeTrue();
            value.ShouldBe(source[i]);
        }
    }

    [Fact]
    public void AsEnumerableResult_EmptySequence_ShouldReturnEmptyResults()
    {
        // Arrange
        var source = Array.Empty<string>();

        // Act
        var results = source.AsEnumerableResult().ToList();

        // Assert
        results.Count.ShouldBe(0);
    }

    [Fact]
    public void AsEnumerableResult_NullSource_ShouldThrowArgumentNullException()
    {
        // Arrange
        IEnumerable<int> source = null!;

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => source.AsEnumerableResult().ToList());
    }

    [Fact]
    public void AsEnumerableResult_ExceptionDuringEnumeration_ShouldReturnFailureResult()
    {
        // Arrange
        var source = new ExceptionThrowingEnumerable<int>();

        // Act
        var results = source.AsEnumerableResult().ToList();

        // Assert
        results.Count.ShouldBe(1);
        results[0].IsSuccess().ShouldBeFalse();
        var error = results[0].Errors.First();
        error.Metadata.ContainsKey("Exception").ShouldBeTrue();
        error.Metadata["Exception"].ShouldBeOfType<InvalidOperationException>();
    }

    [Fact]
    public void AsEnumerableResult_WithDifferentTypes_ShouldWorkCorrectly()
    {
        // Test with different types
        var intResults = new[] { 1, 2, 3 }.AsEnumerableResult().ToList();
        var stringResults = new[] { "a", "b", "c" }.AsEnumerableResult().ToList();
        var boolResults = new[] { true, false, true }.AsEnumerableResult().ToList();

        // Assert
        intResults.ShouldAllBe(r => r.IsSuccess());
        stringResults.ShouldAllBe(r => r.IsSuccess());
        boolResults.ShouldAllBe(r => r.IsSuccess());
    }

    [Fact]
    public void AsEnumerableResult_WithLinqOperations_ShouldWorkCorrectly()
    {
        // Arrange
        var source = new[] { 1, 2, 3, 4, 5 };

        // Act
        var results = source
            .AsEnumerableResult()
            .Where(r => r.IsSuccess())
            .Select(r => r.IsSuccess(out var value) ? value * 2 : 0)
            .ToList();

        // Assert
        results.Count.ShouldBe(5);
        results.ShouldBe(new[] { 2, 4, 6, 8, 10 });
    }

#if NET6_0_OR_GREATER
    [Fact]
    public async Task AsAsyncEnumerableResult_ValidSequence_ShouldReturnAllItemsAsSuccessResults()
    {
        // Arrange
        var source = CreateAsyncEnumerable(["hello", "world", "async"]);

        // Act
        var results = new List<Result<string>>();
        await foreach (var result in source.AsAsyncEnumerableResult())
        {
            results.Add(result);
        }

        // Assert
        results.Count.ShouldBe(3);
        results.ShouldAllBe(r => r.IsSuccess());
        results[0].IsSuccess(out var value1).ShouldBeTrue();
        value1.ShouldBe("hello");
        results[1].IsSuccess(out var value2).ShouldBeTrue();
        value2.ShouldBe("world");
        results[2].IsSuccess(out var value3).ShouldBeTrue();
        value3.ShouldBe("async");
    }

    [Fact]
    public async Task AsAsyncEnumerableResult_EmptySequence_ShouldReturnEmptyResults()
    {
        // Arrange
        var source = CreateAsyncEnumerable(Array.Empty<int>());

        // Act
        var results = new List<Result<int>>();
        await foreach (var result in source.AsAsyncEnumerableResult())
        {
            results.Add(result);
        }

        // Assert
        results.Count.ShouldBe(0);
    }

    private static async IAsyncEnumerable<T> CreateAsyncEnumerable<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            await Task.Delay(1); // Simulate async work
            yield return item;
        }
    }

#endif

    private class ExceptionThrowingEnumerable<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new InvalidOperationException("Test enumeration exception");
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
