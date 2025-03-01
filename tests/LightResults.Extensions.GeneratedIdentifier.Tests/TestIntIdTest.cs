using Shouldly;
using LightResults.Extensions.GeneratedIdentifier.Fixtures.Identifiers;
using LightResults.Extensions.ValueObjects;

// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable EqualExpressionComparison
#pragma warning disable CS1718 // Comparison made to same variable

namespace LightResults.Extensions.GeneratedIdentifier.Tests;

public sealed class TestIntIdTest
{
    [Fact]
    public void Create_ValidValue_ShouldSucceed()
    {
        // Arrange
        const int validValue = 42;

        // Act
        var id = TestIntId.Create(validValue);

        // Assert
        id.ToInt32().ShouldBe(validValue);
    }

    [Fact]
    public void Create_InvalidValue_ShouldThrowException()
    {
        // Arrange
        const int invalidValue = -1;

        // Act
        Func<object?> create = () => TestIntId.Create(invalidValue);

        // Assert
        Should.Throw<ValueObjectException>(create);
    }

    [Fact]
    public void TryCreate_ValidValue_ShouldSucceed()
    {
        // Arrange
        const int validValue = 42;

        // Act
        var result = TestIntId.TryCreate(validValue);

        // Assert
        result.IsSuccess(out var id).ShouldBeTrue();
        id.ToInt32().ShouldBe(validValue);
    }

    [Fact]
    public void TryCreate_InvalidValue_ShouldFail()
    {
        // Arrange
        const int invalidValue = -1;

        // Act
        var result = TestIntId.TryCreate(invalidValue);

        // Assert
        result.IsFailure().ShouldBeTrue();
        result.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public void Parse_ValidString_ShouldSucceed()
    {
        // Arrange
        const string validString = "42";

        // Act
        var result = TestIntId.Parse(validString);

        // Assert
        result.ToInt32().ShouldBe(int.Parse(validString));
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("-1")]
    public void Parse_InvalidString_ShouldThrowException(string invalidString)
    {
        // Act
        Func<object?> parse = () => TestIntId.Parse(invalidString);

        // Assert
        Should.Throw<ValueObjectException>(parse);
    }

    [Fact]
    public void TryParse_ValidString_ShouldSucceed()
    {
        // Arrange
        const string validString = "42";

        // Act
        var result = TestIntId.TryParse(validString);

        // Assert
        result.IsSuccess(out var id).ShouldBeTrue();
        id.ToInt32().ShouldBe(int.Parse(validString));
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("-1")]
    public void TryParse_InvalidString_ShouldFail(string invalidString)
    {
        // Act
        var result = TestIntId.TryParse(invalidString);

        // Assert
        result.IsFailure().ShouldBeTrue();
        result.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public void Equals_SameValues_ShouldBeEqual()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(42);

        // Assert
        id1.ShouldBe(id2);
        (id1 == id2).ShouldBeTrue();
        (id1 != id2).ShouldBeFalse();
    }

    [Fact]
    public void Equals_DifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(99);

        // Assert
        id1.ShouldNotBe(id2);
        (id1 == id2).ShouldBeFalse();
        (id1 != id2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_ObjectIsNull_ShouldReturnFalse()
    {
        // Arrange
        var id = TestIntId.Create(42);

        // Act
        var result = id.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void Equals_ObjectIsNotTestIntId_ShouldReturnFalse()
    {
        // Arrange
        var id = TestIntId.Create(42);

        // Act
        var result = id.Equals("not an TestIntId");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_ShouldReturnCorrectValue()
    {
        // Arrange
        const int underlyingValue = 42;
        var id = TestIntId.Create(underlyingValue);

        // Act
        var hashCode1 = id.GetHashCode();
        var hashCode2 = underlyingValue.GetHashCode();

        // Assert
        hashCode1.ShouldBe(hashCode2);
    }

    [Fact]
    public void Operators_Equality_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(42);

        // Assert
        (id1 == id2).ShouldBeTrue();
        (id1 != id2).ShouldBeFalse();
    }

    [Fact]
    public void Operators_Inequality_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(99);

        // Assert
        (id1 != id2).ShouldBeTrue();
        (id1 == id2).ShouldBeFalse();
    }

    [Fact]
    public void CompareTo_SameValue_ShouldReturnZero()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(42);

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.ShouldBe(0);
    }

    [Fact]
    public void CompareTo_LesserValue_ShouldReturnNegative()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(99);

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.ShouldBeLessThan(0);
    }

    [Fact]
    public void CompareTo_GreaterValue_ShouldReturnPositive()
    {
        // Arrange
        var id1 = TestIntId.Create(99);
        var id2 = TestIntId.Create(42);

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public void Operators_LessThan_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(99);

        // Assert
        (id1 < id2).ShouldBeTrue();
    }

    [Fact]
    public void Operators_GreaterThan_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestIntId.Create(99);
        var id2 = TestIntId.Create(42);

        // Assert
        (id1 > id2).ShouldBeTrue();
    }

    [Fact]
    public void Operators_LessThanOrEqual_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestIntId.Create(42);
        var id2 = TestIntId.Create(99);

        // Assert
        (id1 <= id2).ShouldBeTrue();
        (id1 <= id1).ShouldBeTrue();
    }

    [Fact]
    public void Operators_GreaterThanOrEqual_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestIntId.Create(99);
        var id2 = TestIntId.Create(42);

        // Assert
        (id1 >= id2).ShouldBeTrue();
        (id1 >= id1).ShouldBeTrue();
    }

    [Fact]
    public void CompareTo_ObjectIsNull_ShouldReturnPositive()
    {
        // Arrange
        var id = TestIntId.Create(42);

        // Act
        var result = id.CompareTo(null);

        // Assert
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public void CompareTo_ObjectIsNotTestIntId_ShouldThrowException()
    {
        // Arrange
        var id = TestIntId.Create(42);

        // Act
        Func<object?> compareTo = () => id.CompareTo("not an TestIntId");

        // Assert
        Should.Throw<ArgumentException>(compareTo);
    }

    [Fact]
    public void ToInt_ShouldReturnCorrectValue()
    {
        // Arrange
        var id = TestIntId.Create(42);

        // Act
        var integerValue = id.ToInt32();

        // Assert
        integerValue.ShouldBe(42);
    }

    [Fact]
    public void ToString_ShouldReturnStringValue()
    {
        // Arrange
        var id = TestIntId.Create(42);

        // Act
        var stringValue = id.ToString();

        // Assert
        stringValue.ShouldBe("42");
    }
}

