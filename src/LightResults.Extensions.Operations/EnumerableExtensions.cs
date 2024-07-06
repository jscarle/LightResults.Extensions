using System.Diagnostics;

namespace LightResults.Extensions.Operations;

/// <summary>Extension methods for <see cref="IEnumerable{T}"/>.</summary>
public static class EnumerableExtensions
{
    /// <summary>Combine multiple results into a single result.</summary>
    /// <param name="results">The results to combine.</param>
    /// <returns>
    /// A new successful result if all <paramref name="results"/> were successful; otherwise a new failed result with all errors found in the
    /// <paramref name="results"/>.
    /// </returns>
    /// <remarks>This will enumerate the <paramref name="results"/>.</remarks>
    public static Result Collect(this IEnumerable<Result> results)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(results);
#else
        if (results is null)
            throw new ArgumentNullException(nameof(results));
#endif

        List<IError>? errors = null;
        
        using var enumerator = results.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var next = enumerator.Current;
            if (next.IsSuccess())
                continue;

            errors ??= [];
            errors.AddRange(next.Errors);
        }
        
        return errors is { Count: > 0 } ? Result.Fail(errors.AsReadOnly()) : Result.Ok();
    }

    /// <summary>Combine multiple results into a single result.</summary>
    /// <param name="results">The results to combine.</param>
    /// <returns>
    /// A new successful result if all <paramref name="results"/> were successful; otherwise a new failed result with all errors found in the
    /// <paramref name="results"/>.
    /// </returns>
    public static Result Collect(this IReadOnlyList<Result> results)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(results);
#else
        if (results is null)
            throw new ArgumentNullException(nameof(results));
#endif

        List<IError>? errors = null;
        
        // ReSharper disable once ForCanBeConvertedToForeach
        for(var index = 0; index < results.Count; index++)
        {
            var next = results[index];
            if (next.IsSuccess())
                continue;

            errors ??= [];
            errors.AddRange(next.Errors);
        }
        
        return errors is { Count: > 0 } ? Result.Fail(errors.AsReadOnly()) : Result.Ok();
    }

    /// <summary>Combine multiple results into a single result.</summary>
    /// <param name="results">The results to combine.</param>
    /// <typeparam name="TValue">The type of the value of the result.</typeparam>
    /// <returns>
    /// A new result containing all the values of the <paramref name="results"/> if they were successful; otherwise a failed result with all errors found in
    /// the <paramref name="results"/>.
    /// </returns>
    /// <remarks>This will enumerate the <paramref name="results"/>.</remarks>
    public static Result<IReadOnlyList<TValue>> Collect<TValue>(this IEnumerable<Result<TValue>> results)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(results);
#else
        if (results is null)
            throw new ArgumentNullException(nameof(results));
#endif

        List<TValue>? values = null;
        List<IError>? errors = null;
        
        using var enumerator = results.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var next = enumerator.Current;
            if (errors is null && next.IsSuccess(out var value))
            {
                values ??= [];
                values.Add(value);
            }
            else
            {
                errors ??= [];
                errors.AddRange(next.Errors);
            }
        }
        
        Debug.Assert(errors is { Count: 0 } && values is not null);
        
        return errors is { Count: > 0 } ? Result.Fail<IReadOnlyList<TValue>>(errors.AsReadOnly()) : Result.Ok<IReadOnlyList<TValue>>(values.AsReadOnly());
    }

    /// <summary>Combine multiple results into a single result.</summary>
    /// <param name="results">The results to combine.</param>
    /// <typeparam name="TValue">The type of the value of the result.</typeparam>
    /// <returns>
    /// A new result containing all the values of the <paramref name="results"/> if they were successful; otherwise a failed result with all errors found in
    /// the <paramref name="results"/>.
    /// </returns>
    public static Result<IReadOnlyList<TValue>> Collect<TValue>(this IReadOnlyList<Result<TValue>> results)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(results);
#else
        if (results is null)
            throw new ArgumentNullException(nameof(results));
#endif

        List<TValue>? values = null;
        List<IError>? errors = null;
        
        // ReSharper disable once ForCanBeConvertedToForeach
        for(var index = 0; index < results.Count; index++)
        {
            var next = results[index];
            if (errors is null && next.IsSuccess(out var value))
            {
                values ??= [];
                values.Add(value);
            }
            else
            {
                errors ??= [];
                errors.AddRange(next.Errors);
            }
        }
        
        Debug.Assert(errors is { Count: 0 } && values is not null);
        
        return errors is { Count: > 0 } ? Result.Fail<IReadOnlyList<TValue>>(errors.AsReadOnly()) : Result.Ok<IReadOnlyList<TValue>>(values.AsReadOnly());
    }
}
