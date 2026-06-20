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

    [Fact]
    public void AsEnumerableResult_FullEnumeration_ShouldDisposeEnumerator()
    {
        // Arrange
        var source = new DisposableEnumerable();

        // Act
        _ = source.AsEnumerableResult().ToList();

        // Assert
        source.EnumeratorDisposed.ShouldBeTrue();
    }

    [Fact]
    public void AsEnumerableResult_EarlyEnumerationStop_ShouldDisposeEnumerator()
    {
        // Arrange
        var source = new DisposableEnumerable();

        // Act
        foreach (var _ in source.AsEnumerableResult())
        {
            break;
        }

        // Assert
        source.EnumeratorDisposed.ShouldBeTrue();
    }

    [Fact]
    public void AsEnumerableResult_DisposeThrowsOnFullEnumeration_ShouldReturnFailureResult()
    {
        // Arrange
        var source = new ThrowingDisposeEnumerable();

        // Act
        var results = source.AsEnumerableResult().ToList();

        // Assert
        results.Count.ShouldBe(1);
        results[0].IsSuccess().ShouldBeFalse();
        var error = results[0].Errors.First();
        error.Metadata["Exception"].ShouldBeOfType<InvalidOperationException>();
    }

    [Fact]
    public void AsEnumerableResult_DisposeThrowsAfterEarlyEnumerationStop_ShouldNotThrow()
    {
        // Arrange
        var source = new ThrowingDisposeEnumerable(hasItem: true);

        // Act
        var exception = Record.Exception(() =>
        {
            foreach (var _ in source.AsEnumerableResult())
            {
                break;
            }
        });

        // Assert
        exception.ShouldBeNull();
    }

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

    [Fact]
    public async Task AsAsyncEnumerableResult_FullEnumeration_ShouldDisposeEnumerator()
    {
        // Arrange
        var source = new AsyncDisposableEnumerable();

        // Act
        await foreach (var _ in source.AsAsyncEnumerableResult())
        {
        }

        // Assert
        source.EnumeratorDisposed.ShouldBeTrue();
    }

    [Fact]
    public async Task AsAsyncEnumerableResult_EarlyEnumerationStop_ShouldDisposeEnumerator()
    {
        // Arrange
        var source = new AsyncDisposableEnumerable();

        // Act
        await foreach (var _ in source.AsAsyncEnumerableResult())
        {
            break;
        }

        // Assert
        source.EnumeratorDisposed.ShouldBeTrue();
    }

    [Fact]
    public async Task AsAsyncEnumerableResult_DisposeThrowsOnFullEnumeration_ShouldReturnFailureResult()
    {
        // Arrange
        var source = new ThrowingAsyncDisposeEnumerable();

        // Act
        var results = new List<Result<int>>();
        await foreach (var result in source.AsAsyncEnumerableResult())
        {
            results.Add(result);
        }

        // Assert
        results.Count.ShouldBe(1);
        results[0].IsSuccess().ShouldBeFalse();
        var error = results[0].Errors.First();
        error.Metadata["Exception"].ShouldBeOfType<InvalidOperationException>();
    }

    [Fact]
    public async Task AsAsyncEnumerableResult_DisposeThrowsAfterEarlyEnumerationStop_ShouldNotThrow()
    {
        // Arrange
        var source = new ThrowingAsyncDisposeEnumerable(hasItem: true);

        // Act
        var exception = await Record.ExceptionAsync(async () =>
        {
            await foreach (var _ in source.AsAsyncEnumerableResult())
            {
                break;
            }
        });

        // Assert
        exception.ShouldBeNull();
    }

    private static async IAsyncEnumerable<T> CreateAsyncEnumerable<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            await Task.Delay(1); // Simulate async work
            yield return item;
        }
    }

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

    private sealed class DisposableEnumerable : IEnumerable<int>
    {
        public bool EnumeratorDisposed { get; private set; }

        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private sealed class Enumerator(DisposableEnumerable owner) : IEnumerator<int>
        {
            private int _current;

            public int Current => _current;

            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _current++;
                return _current <= 2;
            }

            public void Reset()
            {
                _current = 0;
            }

            public void Dispose()
            {
                owner.EnumeratorDisposed = true;
            }
        }
    }

    private sealed class ThrowingDisposeEnumerable(bool hasItem = false) : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator(hasItem);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private sealed class Enumerator(bool hasItem) : IEnumerator<int>
        {
            private bool _moved;

            public int Current => 1;

            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (!hasItem || _moved)
                    return false;

                _moved = true;
                return true;
            }

            public void Reset()
            {
                _moved = false;
            }

            public void Dispose()
            {
                throw new InvalidOperationException("Dispose failed.");
            }
        }
    }

    private sealed class AsyncDisposableEnumerable : IAsyncEnumerable<int>
    {
        public bool EnumeratorDisposed { get; private set; }

        public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new Enumerator(this);
        }

        private sealed class Enumerator(AsyncDisposableEnumerable owner) : IAsyncEnumerator<int>
        {
            private int _current;

            public int Current => _current;

            public ValueTask<bool> MoveNextAsync()
            {
                _current++;
                return ValueTask.FromResult(_current <= 2);
            }

            public ValueTask DisposeAsync()
            {
                owner.EnumeratorDisposed = true;
                return ValueTask.CompletedTask;
            }
        }
    }

    private sealed class ThrowingAsyncDisposeEnumerable(bool hasItem = false) : IAsyncEnumerable<int>
    {
        public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new Enumerator(hasItem);
        }

        private sealed class Enumerator(bool hasItem) : IAsyncEnumerator<int>
        {
            private bool _moved;

            public int Current => 1;

            public ValueTask<bool> MoveNextAsync()
            {
                if (!hasItem || _moved)
                    return ValueTask.FromResult(false);

                _moved = true;
                return ValueTask.FromResult(true);
            }

            public ValueTask DisposeAsync()
            {
                return ValueTask.FromException(new InvalidOperationException("DisposeAsync failed."));
            }
        }
    }
}
