namespace LightResults.Extensions.ValueObjects;

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
        ArgumentNullException.ThrowIfNull(result);

        if (result.IsFailure(out var error))
            throw new ValueObjectException(error.Message);
    }
}
