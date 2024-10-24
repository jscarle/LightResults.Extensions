using IResult = LightResults.IResult;

// Resharper disable CheckNamespace
namespace GeneratedIdentifier.Common.ValueObjects;

public sealed class ValueObjectException : Exception
{
    public ValueObjectException()
    {
    }

    public ValueObjectException(string message)
        : base(message)
    {
    }

    public ValueObjectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static void ThrowIfFailed(IResult result)
    {
        if (result.IsFailed(out var error))
            throw new ValueObjectException(error.Message);
    }
}
