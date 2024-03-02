namespace DessertsMakery.Application.Core.Services.WordSimilarity;

public sealed record WordSimilarityRequest(string Source, string Alternative, decimal Precision = 0.7M);
