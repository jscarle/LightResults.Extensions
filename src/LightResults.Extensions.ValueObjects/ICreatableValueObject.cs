using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ValueObjects;

[SuppressMessage("Design", "CA1000: Do not declare static members on generic types", Justification = "This is required for handling value objects generically.")]
[SuppressMessage("Usage", "CA2252: This API requires opting into preview features", Justification = "This is meant to ensure conformity of value objects.")]
public interface ICreatableValueObject<in TValue, TSelf> : IValueObject<TSelf>
    where TSelf : struct
{
    static abstract TSelf Create(TValue value);
    static abstract Result<TSelf> TryCreate(TValue value);
}
