namespace LightResults.Extensions.Operations;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Combine multiple results into a single result.
    /// </summary>
    /// <param name="results">The results to combine.</param>
    /// <returns>
    /// A new successful result if all <paramref name="results"/> were successful;
    /// otherwise a new failed result with all errors found in the <paramref name="results"/>.
    /// </returns>
    /// <remarks>This will enumerate the <paramref name="results"/>.</remarks>
    public static Result Collect(this IEnumerable<Result> results)
    {
        var resultsArray = results as Result[] ?? results.ToArray();
        // Spans are faster to iterate over than arrays
        ReadOnlySpan<Result> resultsSpan = resultsArray;
        var errors = new List<IError>(resultsSpan.Length);

        for (var i = 0; i < resultsSpan.Length; i++)
        {
            if (resultsSpan[i].IsFailed())
                errors.AddRange(resultsSpan[i].Errors);
        }

        return errors.Count == 0
            ? Result.Ok()
            : Result.Fail(errors);
    }

    /// <summary>
    /// Combine multiple results into a single result.
    /// </summary>
    /// <param name="results">The results to combine.</param>
    /// <typeparam name="TValue">The type of the value of the result.</typeparam>
    /// <returns>
    /// A new result containing all the values of the <paramref name="results"/> if they were successful;
    /// otherwise a failed result with all errors found in the <paramref name="results"/>.
    /// </returns>
    /// <remarks>This will enumerate the <paramref name="results"/>.</remarks>
    public static Result<IReadOnlyList<TValue>> Collect<TValue>(this IEnumerable<Result<TValue>> results)
    {
        var resultsArray = results as Result<TValue>[] ?? results.ToArray();
        // Spans are faster to iterate over than arrays
        ReadOnlySpan<Result<TValue>> resultsSpan = resultsArray;
        var values = new List<TValue>(resultsSpan.Length);
        var errors = new List<IError>(resultsSpan.Length);

        for (var i = 0; i < resultsSpan.Length; i++)
        {
            if (resultsSpan[i].IsSuccess(out var value))
                values.Add(value);
            else
                errors.AddRange(resultsSpan[i].Errors);
        }

        return errors.Count == 0
            ? Result.Ok<IReadOnlyList<TValue>>(values)
            : Result.Fail<IReadOnlyList<TValue>>(errors);
    }
}
