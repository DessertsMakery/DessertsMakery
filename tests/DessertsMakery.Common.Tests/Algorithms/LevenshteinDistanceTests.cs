using DessertsMakery.Common.Algorithms;
using FluentAssertions;

namespace DessertsMakery.Common.Tests.Algorithms;

public sealed class LevenshteinDistanceTests
{
    private const string SomeValue = "Milk";
    private const string SlightlyDifferentValue = "Mill";
    private const string FullyDifferentValue = "Bread";

    private readonly LevenshteinDistance _sut;

    public LevenshteinDistanceTests() => _sut = new LevenshteinDistance();

    [Fact]
    public void Calculate_WhenTwoExactlySameValues_ShouldReturnZero()
    {
        // Act
        var actual = _sut.Calculate(SomeValue, SomeValue);

        // Assert
        actual.Should().Be(0);
    }

    [Fact]
    public void Calculate_WhenSlightlyDifferentValues_ShouldReturnOne()
    {
        // Act
        var actual = _sut.Calculate(SomeValue, SlightlyDifferentValue);

        // Assert
        actual.Should().Be(1);
    }

    [Fact]
    public void Calculate_WhenTwoFullyDifferentValues_ShouldReturnPositiveValue()
    {
        // Act
        var actual = _sut.Calculate(SomeValue, FullyDifferentValue);

        // Assert
        actual.Should().BePositive();
    }
}
