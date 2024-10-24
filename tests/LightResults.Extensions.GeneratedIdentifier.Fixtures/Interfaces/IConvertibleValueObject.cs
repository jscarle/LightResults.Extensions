using System.Diagnostics.CodeAnalysis;
using LightResults;

// Resharper disable CheckNamespace
namespace GeneratedIdentifier.Common.ValueObjects;

[SuppressMessage(
    "Design",
    "CA1000: Do not declare static members on generic types",
    Justification = "This is required for handling value objects generically."
)]
public interface IConvertibleValueObject<in TSource, TSelf> : IValueObject<TSelf>
    where TSelf : notnull
{
    static abstract TSelf Convert(TSource source);
    static abstract Result<TSelf> TryConvert(TSource source);
}
