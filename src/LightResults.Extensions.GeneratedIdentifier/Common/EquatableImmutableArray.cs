using System.Collections.Immutable;

namespace LightResults.Extensions.GeneratedIdentifier.Common;

/// <summary>Provides extension methods to convert various collections to an <see cref="EquatableImmutableArray{T}"/>.</summary>
internal static class EquatableImmutableArray
{
    /// <summary>Converts an <see cref="IEnumerable{T}"/> to an <see cref="EquatableImmutableArray{T}"/>.</summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to convert.</param>
    /// <returns>An <see cref="EquatableImmutableArray{T}"/> containing the same elements as the original enumerable.</returns>
    public static EquatableImmutableArray<T> ToEquatableImmutableArray<T>(this IEnumerable<T> enumerable)
    {
        return new EquatableImmutableArray<T>(enumerable.ToImmutableArray());
    }
}
