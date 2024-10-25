using FluentAssertions;
using LightResults.Extensions.GeneratedIdentifier.Fixtures.Identifiers;
using LightResults.Extensions.ValueObjects;

// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable EqualExpressionComparison
#pragma warning disable CS1718 // Comparison made to same variable

namespace LightResults.Extensions.GeneratedIdentifier.Tests;

public sealed class TestStringIdTest
{
    [Fact]
    public void Create_ValidValue_ShouldSucceed()
    {
        // Arrange
        const string validValue = "42";

        // Act
        var id = TestStringId.Create(validValue);

        // Assert
        id.Should()
            .NotBeNull();
        id.ToString()
            .Should()
            .Be(validValue);
    }

    [Fact]
    public void Create_InvalidValue_ShouldThrowException()
    {
        // Arrange
        const string invalidValue = "";

        // Act
        var create = () => TestStringId.Create(invalidValue);

        // Assert
        create.Should()
            .Throw<ValueObjectException>();
    }

    [Fact]
    public void TryCreate_ValidValue_ShouldSucceed()
    {
        // Arrange
        const string validValue = "42";

        // Act
        var result = TestStringId.TryCreate(validValue);

        // Assert
        result.IsSuccess(out var id)
            .Should()
            .BeTrue();
        id.Should()
            .NotBeNull();
        id.ToString()
            .Should()
            .Be(validValue);
    }

    [Fact]
    public void TryCreate_InvalidValue_ShouldFail()
    {
        // Arrange
        const string invalidValue = "";

        // Act
        var result = TestStringId.TryCreate(invalidValue);

        // Assert
        result.IsFailed()
            .Should()
            .BeTrue();
        result.Errors
            .Should()
            .ContainSingle();
    }

    [Fact]
    public void Equals_SameValues_ShouldBeEqual()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("42");

        // Assert
        id1.Should()
            .Be(id2);
        (id1 == id2).Should()
            .BeTrue();
        (id1 != id2).Should()
            .BeFalse();
    }

    [Fact]
    public void Equals_DifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("99");

        // Assert
        id1.Should()
            .NotBe(id2);
        (id1 == id2).Should()
            .BeFalse();
        (id1 != id2).Should()
            .BeTrue();
    }

    [Fact]
    public void Equals_ObjectIsNull_ShouldReturnFalse()
    {
        // Arrange
        var id = TestStringId.Create("42");

        // Act
        var result = id.Equals(null);

        // Assert
        result.Should()
            .BeFalse();
    }

    [Fact]
    public void Equals_ObjectIsNotTestStringId_ShouldReturnFalse()
    {
        // Arrange
        var id = TestStringId.Create("42");

        // Act
        var result = id.Equals("not an TestStringId");

        // Assert
        result.Should()
            .BeFalse();
    }

    [Fact]
    public void GetHashCode_ShouldReturnCorrectValue()
    {
        // Arrange
        const string underlyingValue = "42";
        var id = TestStringId.Create(underlyingValue);

        // Act
        var hashCode1 = id.GetHashCode();
        var hashCode2 = underlyingValue.GetHashCode();

        // Assert
        hashCode1.Should()
            .Be(hashCode2);
    }

    [Fact]
    public void Operators_Equality_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("42");

        // Assert
        (id1 == id2).Should()
            .BeTrue();
        (id1 != id2).Should()
            .BeFalse();
    }

    [Fact]
    public void Operators_Inequality_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("99");

        // Assert
        (id1 != id2).Should()
            .BeTrue();
        (id1 == id2).Should()
            .BeFalse();
    }

    [Fact]
    public void CompareTo_SameValue_ShouldReturnZero()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("42");

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.Should()
            .Be(0);
    }

    [Fact]
    public void CompareTo_LesserValue_ShouldReturnNegative()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("99");

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.Should()
            .BeNegative();
    }

    [Fact]
    public void CompareTo_GreaterValue_ShouldReturnPositive()
    {
        // Arrange
        var id1 = TestStringId.Create("99");
        var id2 = TestStringId.Create("42");

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.Should()
            .BePositive();
    }

    [Fact]
    public void Operators_LessThan_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("99");

        // Assert
        (id1 < id2).Should()
            .BeTrue();
    }

    [Fact]
    public void Operators_GreaterThan_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestStringId.Create("99");
        var id2 = TestStringId.Create("42");

        // Assert
        (id1 > id2).Should()
            .BeTrue();
    }

    [Fact]
    public void Operators_LessThanOrEqual_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestStringId.Create("42");
        var id2 = TestStringId.Create("99");

        // Assert
        (id1 <= id2).Should()
            .BeTrue();
        (id1 <= id1).Should()
            .BeTrue();
    }

    [Fact]
    public void Operators_GreaterThanOrEqual_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestStringId.Create("99");
        var id2 = TestStringId.Create("42");

        // Assert
        (id1 >= id2).Should()
            .BeTrue();
        (id1 >= id1).Should()
            .BeTrue();
    }

    [Fact]
    public void CompareTo_ObjectIsNull_ShouldReturnPositive()
    {
        // Arrange
        var id = TestStringId.Create("42");

        // Act
        var result = id.CompareTo(null);

        // Assert
        result.Should()
            .BePositive();
    }

    [Fact]
    public void CompareTo_ObjectIsNotTestStringId_ShouldThrowException()
    {
        // Arrange
        var id = TestStringId.Create("42");

        // Act
        var compareTo = () => id.CompareTo("not an TestStringId");

        // Assert
        compareTo.Should()
            .Throw<ArgumentException>();
    }

    [Fact]
    public void ToInt_ShouldReturnCorrectValue()
    {
        // Arrange
        var id = TestStringId.Create("42");

        // Act
        var integerValue = id.ToString();

        // Assert
        integerValue.Should()
            .Be("42");
    }

    [Fact]
    public void ToString_ShouldReturnStringValue()
    {
        // Arrange
        var id = TestStringId.Create("42");

        // Act
        var stringValue = id.ToString();

        // Assert
        stringValue.Should()
            .Be("42");
    }
}
