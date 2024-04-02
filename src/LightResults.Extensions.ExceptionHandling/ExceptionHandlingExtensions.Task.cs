namespace LightResults.Extensions.ExceptionHandling;

public static partial class ExceptionHandlingExtensions
{
    /// <summary>Attempts to execute a task and returns a <see cref="Task{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="task">The task to attempt.</param>
    /// <returns>A <see cref="Task{Result}"/> indicating success or failure.</returns>
    public static Task<Result> TryAsync(this Task task)
    {
        return ExceptionHandler.TryAsync(task);
    }

    /// <summary>Attempts to execute a task and returns a <see cref="Task{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="task">The task to attempt.</param>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A <see cref="Task{Result}"/> indicating success or failure.</returns>
    public static Task<Result<TResult>> TryAsync<TResult>(this Task<TResult> task)
    {
        return ExceptionHandler.TryAsync(task);
    }
}
