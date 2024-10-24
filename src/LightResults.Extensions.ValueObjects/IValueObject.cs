using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ValueObjects;

public interface IValueObject<out TValue, TSelf> : IValueObject<TSelf>
    where TSelf : struct
{
    TValue Value { get; }
}

public interface IValueObject<TSelf> : IValueObject, IEquatable<TSelf>
    where TSelf : struct;

[SuppressMessage("Design", "CA1040: Avoid empty interfaces", Justification = "Used as a marker interface.")]
public interface IValueObject;
