using DessertsMakery.Common.Algorithms;

namespace DessertsMakery.Application.Core.Services.WordSimilarity;

internal sealed class WorkSimilarityChecker : IWorkSimilarityChecker, IService
{
    private readonly ILevenshteinDistance _levenshteinDistance;

    public WorkSimilarityChecker(ILevenshteinDistance levenshteinDistance)
    {
        _levenshteinDistance = levenshteinDistance;
    }

    public bool Check(WordSimilarityRequest request)
    {
        var (source, alternative, precision) = request;
        decimal distance = _levenshteinDistance.Calculate(source, alternative);
        var proportion = (source.Length - distance) / source.Length;
        return proportion >= precision;
    }
}
