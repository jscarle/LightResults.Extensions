namespace LightResults.Extensions.ExceptionHandling;

public static partial class ExceptionHandlingExtensions
{
    /// <summary>Attempts to execute a value task and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="valueTask">The value task to attempt.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result> TryAsync(this ValueTask valueTask)
    {
        return ExceptionHandler.TryAsync(valueTask);
    }

    /// <summary>Attempts to execute a value task and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="valueTask">The value task to attempt.</param>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<TResult>(this ValueTask<TResult> valueTask)
    {
        return ExceptionHandler.TryAsync(valueTask);
    }
}
