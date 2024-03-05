using CSharpFunctionalExtensions;

namespace DessertsMakery.Application.Core.Services.WordSimilarity;

public interface IWordSimilarityChecker
{
    Maybe<WordSimilarityResponse> Check(WordSimilarityRequest request);
}
