namespace DessertsMakery.Application.Core.Services.WordSimilarity;

public sealed record WordSimilarityResponse(string Source, WordSimilarity Similarity)
{
    public WordSimilarityResponse(string source, string alternative, decimal coefficient)
        : this(source, new WordSimilarity(alternative, coefficient)) { }
}
