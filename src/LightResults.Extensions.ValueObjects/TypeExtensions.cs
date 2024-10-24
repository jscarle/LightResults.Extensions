using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ValueObjects;

public static class TypeExtensions
{
    public static bool IsValueObjectType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)] this Type type, out Type valueObjectType)
    {
        ArgumentNullException.ThrowIfNull(type);

        var valueObjectInterface = type.GetGenericInterfaceOrDefault(typeof(IValueObject<,>));
        if (valueObjectInterface is null && type.IsValueType)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            valueObjectInterface = underlyingType?.GetGenericInterfaceOrDefault(typeof(IValueObject<,>));
        }
        if (valueObjectInterface is null)
        {
            valueObjectType = default!;
            return false;
        }

        valueObjectType = valueObjectInterface.GenericTypeArguments[0];
        return true;
    }

    /// <summary>Gets the generic interface type implemented by the current type that matches the specified generic type.</summary>
    /// <param name="type">The type to check.</param>
    /// <param name="genericType">The generic interface type to find.</param>
    /// <returns>A type representing the generic interface, or null if no match is found.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="genericType"/> is not a generic type.</exception>
    private static Type? GetGenericInterfaceOrDefault([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)] this Type type, Type genericType)
    {
        if (!genericType.IsGenericType)
            throw new ArgumentException($"The type {genericType.Name} is not a generic type.", nameof(genericType));

        return Array.Find(type.GetInterfaces(), x => x == genericType || (x.IsGenericType && x.GetGenericTypeDefinition() == genericType));
    }
}
