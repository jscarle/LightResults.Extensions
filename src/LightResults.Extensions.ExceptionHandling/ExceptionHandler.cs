namespace LightResults.Extensions.ExceptionHandling;

/// <summary>Provides extension methods for handling exceptions using the <see cref="Result" /> type.</summary>
public static partial class ExceptionHandler
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
