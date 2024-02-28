using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ExceptionHandling;

// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
/// <summary>
/// Provides extension methods for handling exceptions using the <see cref="Result"/> type.
/// </summary>
[SuppressMessage("Design", "CA1031: Do not catch general exception types", Justification = "We intentionally want to capture all exceptions.")]
public static class ExceptionHandlingExtensions
{
    private const string ExceptionKey = "Exception";

    /// <summary>
    /// Attempts to execute an action and returns a <see cref="Result"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="action">The action to attempt.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure.</returns>
    public static Result Try(this Action action)
    {
        try
        {
            action?.Invoke();
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }

        return Result.Ok();
    }

    /// <summary>
    /// Attempts to execute an action with a single parameter and returns a <see cref="Result"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <param name="action">The action to attempt.</param>
    /// <param name="p1">The first parameter.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure.</returns>
    public static Result Try<T1>(this Action<T1> action, T1 p1)
    {
        try
        {
            action?.Invoke(p1);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }

        return Result.Ok();
    }

    /// <summary>
    /// Attempts to execute an action with two parameters and returns a <see cref="Result"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <param name="action">The action to attempt.</param>
    /// <param name="p1">The first parameter.</param>
    /// <param name="p2">The second parameter.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure.</returns>
    public static Result Try<T1, T2>(this Action<T1, T2> action, T1 p1, T2 p2)
    {
        try
        {
            action?.Invoke(p1, p2);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }

        return Result.Ok();
    }

    private static Result HandleException(Exception ex)
    {
        var error = GetExceptionError(ex);
        return Result.Fail(error);
    }

    private static Error GetExceptionError(Exception ex)
    {
        var message = GetExceptionMessage(ex);
        var error = new Error(message, (ExceptionKey, ex));
        return error;
    }

    private static string GetExceptionMessage(Exception ex)
    {
        return $"{ex.GetType().Name}: {ex.Message}";
    }
}
