using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ValueObjects;

public interface IValueObject<out TValue, TSelf> : IValueObject<TSelf>
    where TSelf : notnull
{
    TValue Value { get; }
}

public interface IValueObject<TSelf> : IValueObject, IEquatable<TSelf>
    where TSelf : notnull;

[SuppressMessage("Design", "CA1040: Avoid empty interfaces", Justification = "Used as a marker interface.")]
public interface IValueObject;
