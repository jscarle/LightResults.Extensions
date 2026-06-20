using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LightResults.Extensions.ExceptionHandling;

/// <summary>
/// Provides extension methods for <see cref="IEnumerable{T}"/> and <see cref="IAsyncEnumerable{T}"/>
/// that wrap enumeration in <see cref="Result{T}"/> to capture exceptions as failed results.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Enumerates the elements of the sequence, wrapping each element in a <see cref="Result{T}"/>.
    /// If an exception occurs during enumeration, yields a failed <see cref="Result{T}"/> containing the exception.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The sequence to enumerate.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="Result{T}"/> objects, where each successful result contains
    /// an item from <paramref name="source"/>, or a failure result contains the exception thrown during enumeration.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
    /// <exception cref="UnreachableException">The enumerator could not be obtained from <paramref name="source"/>.</exception>
    public static IEnumerable<Result<T>> AsEnumerableResult<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        Exception? exception = null;

        IEnumerator<T>? enumerator = null;
        try
        {
            enumerator = source.GetEnumerator();
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        if (exception is not null)
        {
            yield return Result.Failure<T>(exception);
            if (enumerator is not null)
            {
                var disposeException = DisposeEnumerator(enumerator);
                if (disposeException is not null)
                    yield return Result.Failure<T>(disposeException);
            }

            yield break;
        }

        if (enumerator is null)
            throw new UnreachableException("The enumerator was unexpectedly null.");

        try
        {
            while (true)
            {
                exception = null;

                bool hasMoreItems;
                try
                {
                    hasMoreItems = enumerator.MoveNext();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    hasMoreItems = false;
                }

                if (exception is not null)
                {
                    yield return Result.Failure<T>(exception);
                    var disposeException = DisposeEnumerator(enumerator);
                    enumerator = null;
                    if (disposeException is not null)
                        yield return Result.Failure<T>(disposeException);

                    yield break;
                }

                if (!hasMoreItems)
                {
                    var disposeException = DisposeEnumerator(enumerator);
                    enumerator = null;
                    if (disposeException is not null)
                        yield return Result.Failure<T>(disposeException);

                    yield break;
                }

                T current = default(T)!;
                try
                {
                    current = enumerator.Current;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                if (exception is not null)
                {
                    yield return Result.Failure<T>(exception);
                    var disposeException = DisposeEnumerator(enumerator);
                    enumerator = null;
                    if (disposeException is not null)
                        yield return Result.Failure<T>(disposeException);

                    yield break;
                }

                yield return Result.Success(current);
            }
        }
        finally
        {
            if (enumerator is not null)
                _ = DisposeEnumerator(enumerator);
        }
    }

    /// <summary>
    /// Asynchronously enumerates the elements of the sequence, wrapping each element in a <see cref="Result{T}"/>.
    /// If an exception occurs during asynchronous enumeration, yields a failed <see cref="Result{T}"/> containing the exception.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The asynchronous sequence to enumerate.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous enumeration.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{T}"/> objects, where each successful result contains
    /// an item from <paramref name="source"/>, or a failure result contains the exception thrown during asynchronous enumeration.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
    /// <exception cref="UnreachableException">The asynchronous enumerator could not be obtained from <paramref name="source"/>.</exception>
    public static async IAsyncEnumerable<Result<T>> AsAsyncEnumerableResult<T>(
        this IAsyncEnumerable<T> source,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(source);

        Exception? exception = null;

        IAsyncEnumerator<T>? enumerator = null;
        try
        {
            enumerator = source.GetAsyncEnumerator(cancellationToken);
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        if (exception is not null)
        {
            yield return Result.Failure<T>(exception);
            if (enumerator is not null)
            {
                var disposeException = await DisposeAsyncEnumerator(enumerator)
                    .ConfigureAwait(false);
                if (disposeException is not null)
                    yield return Result.Failure<T>(disposeException);
            }

            yield break;
        }

        if (enumerator is null)
            throw new UnreachableException("The enumerator was unexpectedly null.");

        try
        {
            while (true)
            {
                exception = null;

                bool hasMoreItems;
                try
                {
                    hasMoreItems = await enumerator.MoveNextAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    hasMoreItems = false;
                }

                if (exception is not null)
                {
                    yield return Result.Failure<T>(exception);
                    var disposeException = await DisposeAsyncEnumerator(enumerator)
                        .ConfigureAwait(false);
                    enumerator = null;
                    if (disposeException is not null)
                        yield return Result.Failure<T>(disposeException);

                    yield break;
                }

                if (!hasMoreItems)
                {
                    var disposeException = await DisposeAsyncEnumerator(enumerator)
                        .ConfigureAwait(false);
                    enumerator = null;
                    if (disposeException is not null)
                        yield return Result.Failure<T>(disposeException);

                    yield break;
                }

                T current = default(T)!;
                try
                {
                    current = enumerator.Current;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                if (exception is not null)
                {
                    yield return Result.Failure<T>(exception);
                    var disposeException = await DisposeAsyncEnumerator(enumerator)
                        .ConfigureAwait(false);
                    enumerator = null;
                    if (disposeException is not null)
                        yield return Result.Failure<T>(disposeException);

                    yield break;
                }

                yield return Result.Success(current);
            }
        }
        finally
        {
            if (enumerator is not null)
                _ = await DisposeAsyncEnumerator(enumerator)
                    .ConfigureAwait(false);
        }
    }

    private static Exception? DisposeEnumerator<T>(IEnumerator<T> enumerator)
    {
        try
        {
            enumerator.Dispose();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    private static async ValueTask<Exception?> DisposeAsyncEnumerator<T>(IAsyncEnumerator<T> enumerator)
    {
        try
        {
            await enumerator.DisposeAsync()
                .ConfigureAwait(false);
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
