using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ExceptionHandling;

/// <summary>Provides extension methods for handling exceptions using the <see cref="Result" /> type.</summary>
[SuppressMessage("Design", "CA1031: Do not catch general exception types", Justification = "We intentionally want to capture all exceptions.")]
public static partial class ExceptionHandlingExtensions
{
    private const string ExceptionKey = "Exception";

    private static Result HandleException(Exception ex)
    {
        var error = GetExceptionError(ex);
        return Result.Fail(error);
    }

    private static Result<TResult> HandleException<TResult>(Exception ex)
    {
        var error = GetExceptionError(ex);
        return Result<TResult>.Fail(error);
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