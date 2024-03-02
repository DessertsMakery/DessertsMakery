namespace DessertsMakery.Application.Core.Services.WordSimilarity;

public interface IWorkSimilarityChecker
{
    bool Check(WordSimilarityRequest request);
}
