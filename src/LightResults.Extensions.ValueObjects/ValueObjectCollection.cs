using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.ValueObjects;

[SuppressMessage("Design", "CA1000: Do not declare static members on generic types", Justification = "This is required for handling value objects generically."
)]
public readonly struct ValueObjectCollection<TValue> : IParsableValueObject<ValueObjectCollection<TValue>>, IReadOnlyCollection<TValue>
    where TValue : struct, IParsableValueObject<TValue>
{
    public static ValueObjectCollection<TValue> Empty { get; } = new(ImmutableArray<TValue>.Empty);

    public int Count => _values.IsDefault ? 0 : _values.Length;

    private readonly ImmutableArray<TValue> _values;

    private ValueObjectCollection(ImmutableArray<TValue> values)
    {
        _values = values;
    }

    public static ValueObjectCollection<TValue> Parse(string s)
    {
        if (TryParse(s)
            .IsSuccess(out var collection, out var error))
            return collection;

        throw new ValueObjectException(error.Message);
    }

    public static Result<ValueObjectCollection<TValue>> TryParse(string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        var builder = ImmutableArray.CreateBuilder<TValue>();
        var matches = s.Split(',');
        foreach (var match in matches)
        {
            if (TValue.TryParse(match)
                .IsSuccess(out var valueObject, out var error))
                builder.Add(valueObject);
            else
                return Result.Fail<ValueObjectCollection<TValue>>(error);
        }
        var values = new ValueObjectCollection<TValue>(builder.ToImmutable());
        return Result.Ok(values);
    }

    public static bool TryParse(string s, out ValueObjectCollection<TValue> valueObjectCollection)
    {
        return TryParse(s)
            .IsSuccess(out valueObjectCollection);
    }

    public static bool TryParse(string s, IFormatProvider provider, out ValueObjectCollection<TValue> valueObjectCollection)
    {
        return TryParse(s)
            .IsSuccess(out valueObjectCollection);
    }

    #region IEquatable

    public bool Equals(ValueObjectCollection<TValue> other)
    {
        return !_values.IsDefault && _values.SequenceEqual(other._values);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObjectCollection<TValue> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _values.GetHashCode();
    }

    public static bool operator ==(ValueObjectCollection<TValue> left, ValueObjectCollection<TValue> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ValueObjectCollection<TValue> left, ValueObjectCollection<TValue> right)
    {
        return !left.Equals(right);
    }

    #endregion

    public override string ToString()
    {
        return _values.IsDefault ? "" : string.Join(',', _values);
    }

    public IEnumerator<TValue> GetEnumerator()
    {
        if (_values.IsDefault)
            yield break;

        foreach (var projectModelTagId in _values)
            yield return projectModelTagId;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
