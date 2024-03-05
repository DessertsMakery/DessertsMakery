using CSharpFunctionalExtensions;
using DessertsMakery.Common.Algorithms;

namespace DessertsMakery.Application.Core.Services.WordSimilarity;

internal sealed class WordSimilarityChecker : IWordSimilarityChecker, IService
{
    private readonly ILevenshteinDistance _levenshteinDistance;

    public WordSimilarityChecker(ILevenshteinDistance levenshteinDistance)
    {
        _levenshteinDistance = levenshteinDistance;
    }

    public Maybe<WordSimilarityResponse> Check(WordSimilarityRequest request)
    {
        var (source, alternative, precision) = request;
        decimal distance = _levenshteinDistance.Calculate(source, alternative);
        var coefficient = (source.Length - distance) / source.Length;
        if (coefficient < precision)
        {
            return Maybe.None;
        }

        return new WordSimilarityResponse(source, alternative, coefficient);
    }
}
