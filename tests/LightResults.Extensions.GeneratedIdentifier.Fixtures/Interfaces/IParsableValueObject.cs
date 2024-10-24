using System.Diagnostics.CodeAnalysis;
using LightResults;

// Resharper disable CheckNamespace
namespace GeneratedIdentifier.Common.ValueObjects;

[SuppressMessage(
    "Design",
    "CA1000: Do not declare static members on generic types",
    Justification = "This is required for handling value objects generically."
)]
public interface IParsableValueObject<TSelf> : IValueObject<TSelf>
    where TSelf : notnull
{
    static abstract TSelf Parse(string s);
    static abstract Result<TSelf> TryParse(string s);
    static abstract bool TryParse(string s, out TSelf result);
    static abstract bool TryParse(string s, IFormatProvider provider, out TSelf result);
}
