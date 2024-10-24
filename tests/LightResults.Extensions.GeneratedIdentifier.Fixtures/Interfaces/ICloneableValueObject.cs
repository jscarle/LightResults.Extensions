// Resharper disable CheckNamespace

namespace GeneratedIdentifier.Common.ValueObjects;

public interface ICloneableValueObject<TSelf> : IValueObject<TSelf>
    where TSelf : notnull
{
    TSelf Clone();
}
