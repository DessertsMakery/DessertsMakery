using DessertsMakery.Application.Core.Services.WordSimilarity;
using DessertsMakery.Common.Algorithms;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;

namespace DessertsMakery.Application.Core.Tests.Services.WordSimilarity;

public sealed class WorkSimilarityCheckerTests
{
    private const string AnyWord = nameof(AnyWord);
    private const string SomeAnotherWord = nameof(SomeAnotherWord);
    private readonly Mock<ILevenshteinDistance> _levenshteinDistanceMock;
    private readonly WordSimilarityChecker _sut;

    public WorkSimilarityCheckerTests()
    {
        _levenshteinDistanceMock = new Mock<ILevenshteinDistance>();
        _sut = new WordSimilarityChecker(_levenshteinDistanceMock.Object);
    }

    [Fact]
    public void Check_WhenLevenshteinDistanceIsZero_ShouldReturnSimilarityWithCoefficientOne()
    {
        // Arrange
        const int zeroDistance = 0;
        var request = new WordSimilarityRequest(AnyWord, SomeAnotherWord);
        _levenshteinDistanceMock.Setup(x => x.Calculate(AnyWord, SomeAnotherWord)).Returns(zeroDistance);

        // Act
        var actual = _sut.Check(request);

        // Assert
        using (new AssertionScope())
        {
            actual.HasValue.Should().BeTrue();
            actual
                .Value.Should()
                .BeEquivalentTo(
                    new { Source = AnyWord, Similarity = new { Alternative = SomeAnotherWord, Coefficient = 1 } }
                );
        }
    }
}
