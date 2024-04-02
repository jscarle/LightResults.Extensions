namespace LightResults.Extensions.ExceptionHandling;

public static partial class ExceptionHandler
{
    /// <summary>Attempts to execute a task and returns a <see cref="Task{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="task">The task to attempt.</param>
    /// <returns>A <see cref="Task{Result}"/> indicating success or failure.</returns>
    public static async Task<Result> TryAsync(Task task)
    {
        try
        {
            await task.ConfigureAwait(false);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    /// <summary>Attempts to execute a task and returns a <see cref="Task{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="task">The task to attempt.</param>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A <see cref="Task{Result}"/> indicating success or failure.</returns>
    public static async Task<Result<TResult>> TryAsync<TResult>(Task<TResult> task)
    {
        try
        {
            var result = await task.ConfigureAwait(false);
            return Result<TResult>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<TResult>(ex);
        }
    }
}
