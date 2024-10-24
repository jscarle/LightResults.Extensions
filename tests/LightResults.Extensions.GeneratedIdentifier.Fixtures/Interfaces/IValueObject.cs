// Resharper disable CheckNamespace

namespace GeneratedIdentifier.Common.ValueObjects;

public interface IValueObject<out TValue, TSelf> : IValueObject<TSelf>
    where TSelf : notnull
{
    TValue Value { get; }
}

public interface IValueObject<TSelf> : IValueObject, IEquatable<TSelf>, IComparable<TSelf>, IComparable
    where TSelf : notnull;

public interface IValueObject;
