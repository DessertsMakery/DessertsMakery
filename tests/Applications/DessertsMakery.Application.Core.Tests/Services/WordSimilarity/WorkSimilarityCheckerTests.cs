using DessertsMakery.Application.Core.Services.WordSimilarity;
using DessertsMakery.Common.Algorithms;
using FluentAssertions;
using Moq;

namespace DessertsMakery.Application.Core.Tests.Services.WordSimilarity;

public sealed class WorkSimilarityCheckerTests
{
    private const string AnyWord = nameof(AnyWord);
    private const string SomeAnotherWord = nameof(SomeAnotherWord);
    private readonly Mock<ILevenshteinDistance> _levenshteinDistanceMock;
    private readonly WorkSimilarityChecker _sut;

    public WorkSimilarityCheckerTests()
    {
        _levenshteinDistanceMock = new Mock<ILevenshteinDistance>();
        _sut = new WorkSimilarityChecker(_levenshteinDistanceMock.Object);
    }

    [Fact]
    public void Check_WhenLevenshteinDistanceIsZero_ShouldReturnTrue()
    {
        // Arrange
        const int zeroDistance = 0;
        var request = new WordSimilarityRequest(AnyWord, SomeAnotherWord);
        _levenshteinDistanceMock.Setup(x => x.Calculate(AnyWord, SomeAnotherWord)).Returns(zeroDistance);

        // Act
        var actual = _sut.Check(request);

        // Assert
        actual.Should().BeTrue();
    }
}
