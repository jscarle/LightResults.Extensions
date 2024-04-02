namespace LightResults.Extensions.ExceptionHandling;

public static partial class ExceptionHandler
{
    /// <summary>Attempts to execute a value task and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="valueTask">The value task to attempt.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static async ValueTask<Result> TryAsync(ValueTask valueTask)
    {
        try
        {
            await valueTask.ConfigureAwait(false);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    /// <summary>Attempts to execute a value task and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="valueTask">The value task to attempt.</param>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static async ValueTask<Result<TResult>> TryAsync<TResult>(ValueTask<TResult> valueTask)
    {
        try
        {
            var result = await valueTask.ConfigureAwait(false);
            return Result<TResult>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<TResult>(ex);
        }
    }
}
