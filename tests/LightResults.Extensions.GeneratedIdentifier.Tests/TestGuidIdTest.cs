using Shouldly;
using LightResults.Extensions.GeneratedIdentifier.Fixtures.Identifiers;
using LightResults.Extensions.ValueObjects;

// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable EqualExpressionComparison
#pragma warning disable CS1718 // Comparison made to same variable

namespace LightResults.Extensions.GeneratedIdentifier.Tests;

public sealed class TestGuidIdTest
{
    private static readonly Guid Guid1 = Guid.Parse("bcbac1e2-de00-47e4-9891-58774a68668f");
    private static readonly Guid Guid2 = Guid.Parse("e8d81b8f-127f-4e7d-b7fb-c9ab6f34be72");

    [Fact]
    public void Create_ValidValue_ShouldSucceed()
    {
        // Arrange
        var validValue = Guid1;

        // Act
        var id = TestGuidId.Create(validValue);

        // Assert
        id.ToGuid().ShouldBe(validValue);
    }

    [Fact]
    public void TryCreate_ValidValue_ShouldSucceed()
    {
        // Arrange
        var validValue = Guid1;

        // Act
        var result = TestGuidId.TryCreate(validValue);

        // Assert
        result.IsSuccess(out var id).ShouldBeTrue();
        id.ToGuid().ShouldBe(validValue);
    }

    [Fact]
    public void Parse_ValidString_ShouldSucceed()
    {
        // Arrange
        const string validString = "5528cc73-cba9-4960-85c1-ed96dc4c7f95";

        // Act
        var result = TestGuidId.Parse(validString);

        // Assert
        result.ToGuid().ShouldBe(Guid.Parse(validString));
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("g528cc73-cba9-4960-85c1-ed96dc4c7f95")]
    public void Parse_InvalidString_ShouldThrowException(string invalidString)
    {
        // Act
        Func<object?> parse = () => TestGuidId.Parse(invalidString);

        // Assert
        Should.Throw<ValueObjectException>(parse);
    }

    [Fact]
    public void TryParse_ValidString_ShouldSucceed()
    {
        // Arrange
        const string validString = "5528cc73-cba9-4960-85c1-ed96dc4c7f95";

        // Act
        var result = TestGuidId.TryParse(validString);

        // Assert
        result.IsSuccess(out var id).ShouldBeTrue();
        id.ToGuid().ShouldBe(Guid.Parse(validString));
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("-1")]
    public void TryParse_InvalidString_ShouldFail(string invalidString)
    {
        // Act
        var result = TestGuidId.TryParse(invalidString);

        // Assert
        result.IsFailure().ShouldBeTrue();
        result.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public void Equals_SameValues_ShouldBeEqual()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid1);

        // Assert
        id1.ShouldBe(id2);
        (id1 == id2).ShouldBeTrue();
        (id1 != id2).ShouldBeFalse();
    }

    [Fact]
    public void Equals_DifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid2);

        // Assert
        id1.ShouldNotBe(id2);
        (id1 == id2).ShouldBeFalse();
        (id1 != id2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_ObjectIsNull_ShouldReturnFalse()
    {
        // Arrange
        var id = TestGuidId.Create(Guid1);

        // Act
        var result = id.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void Equals_ObjectIsNotTestGuidId_ShouldReturnFalse()
    {
        // Arrange
        var id = TestGuidId.Create(Guid1);

        // Act
        var result = id.Equals("not an TestGuidId");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_ShouldReturnCorrectValue()
    {
        // Arrange
        var underlyingValue = Guid1;
        var id = TestGuidId.Create(underlyingValue);

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
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid1);

        // Assert
        (id1 == id2).ShouldBeTrue();
        (id1 != id2).ShouldBeFalse();
    }

    [Fact]
    public void Operators_Inequality_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid2);

        // Assert
        (id1 != id2).ShouldBeTrue();
        (id1 == id2).ShouldBeFalse();
    }

    [Fact]
    public void CompareTo_SameValue_ShouldReturnZero()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid1);

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.ShouldBe(0);
    }

    [Fact]
    public void CompareTo_LesserValue_ShouldReturnNegative()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid2);

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.ShouldBeLessThan(0);
    }

    [Fact]
    public void CompareTo_GreaterValue_ShouldReturnPositive()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid2);
        var id2 = TestGuidId.Create(Guid1);

        // Act
        var result = id1.CompareTo(id2);

        // Assert
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public void Operators_LessThan_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid2);

        // Assert
        (id1 < id2).ShouldBeTrue();
    }

    [Fact]
    public void Operators_GreaterThan_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid2);
        var id2 = TestGuidId.Create(Guid1);

        // Assert
        (id1 > id2).ShouldBeTrue();
    }

    [Fact]
    public void Operators_LessThanOrEqual_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid1);
        var id2 = TestGuidId.Create(Guid2);

        // Assert
        (id1 <= id2).ShouldBeTrue();
        (id1 <= id1).ShouldBeTrue();
    }

    [Fact]
    public void Operators_GreaterThanOrEqual_ShouldReturnTrue()
    {
        // Arrange
        var id1 = TestGuidId.Create(Guid2);
        var id2 = TestGuidId.Create(Guid1);

        // Assert
        (id1 >= id2).ShouldBeTrue();
        (id1 >= id1).ShouldBeTrue();
    }

    [Fact]
    public void CompareTo_ObjectIsNull_ShouldReturnPositive()
    {
        // Arrange
        var id = TestGuidId.Create(Guid1);

        // Act
        var result = id.CompareTo(null);

        // Assert
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public void CompareTo_ObjectIsNotTestGuidId_ShouldThrowException()
    {
        // Arrange
        var id = TestGuidId.Create(Guid1);

        // Act
        Func<object?> compareTo = () => id.CompareTo("not an TestGuidId");

        // Assert
        Should.Throw<ArgumentException>(compareTo);
    }

    [Fact]
    public void ToInt_ShouldReturnCorrectValue()
    {
        // Arrange
        var id = TestGuidId.Create(Guid1);

        // Act
        var integerValue = id.ToGuid();

        // Assert
        integerValue.ShouldBe(Guid1);
    }

    [Fact]
    public void ToString_ShouldReturnStringValue()
    {
        // Arrange
        var id = TestGuidId.Create(Guid1);

        // Act
        var stringValue = id.ToString();

        // Assert
        stringValue.ShouldBe(Guid1.ToString());
    }
}
