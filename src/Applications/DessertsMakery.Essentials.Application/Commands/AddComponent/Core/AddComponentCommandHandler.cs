using CSharpFunctionalExtensions;
using DessertsMakery.Application.Core.Services.WordSimilarity;
using DessertsMakery.Persistence.Models.Essentials;
using DessertsMakery.Persistence.Repositories.Components;
using MediatR;
using OneOf;

namespace DessertsMakery.Essentials.Application.Commands.AddComponent.Core;

internal abstract class AddComponentCommandHandler<TRequest, TComponent>
    : IRequestHandler<TRequest, OneOf<TComponent, SimilaritiesFound<TComponent>>>
    where TRequest : AddComponentCommand<TComponent>
    where TComponent : Component
{
    private readonly IWordSimilarityChecker _wordSimilarityChecker;

    protected IReadWriteComponentRepository ComponentRepository { get; }

    protected AddComponentCommandHandler(
        IWordSimilarityChecker wordSimilarityChecker,
        IReadWriteComponentRepository componentRepository
    )
    {
        _wordSimilarityChecker = wordSimilarityChecker;
        ComponentRepository = componentRepository;
    }

    public async Task<OneOf<TComponent, SimilaritiesFound<TComponent>>> Handle(
        TRequest request,
        CancellationToken cancellationToken
    )
    {
        var components = await GetAllComponentsAsync(token: cancellationToken);

        if (TryGetSimilarities(request, components) is { Length: > 0 } componentWithSimilarities)
        {
            return SimilaritiesFound(componentWithSimilarities);
        }

        var component = await ComponentFromAsync(request, cancellationToken);
        var created = await ComponentRepository.CreateAsync(component, cancellationToken);
        return created;
    }

    protected abstract Task<IReadOnlyCollection<TComponent>> GetAllComponentsAsync(CancellationToken token);

    protected abstract Task<TComponent> ComponentFromAsync(TRequest command, CancellationToken token);

    private ComponentWithSimilarity[] TryGetSimilarities(TRequest request, IEnumerable<TComponent> components)
    {
        return components.AsParallel().Select(WithSimilarity).Where(x => x.HasValue).Select(x => x.Value).ToArray();

        Maybe<ComponentWithSimilarity> WithSimilarity(TComponent component) =>
            _wordSimilarityChecker
                .Check(new WordSimilarityRequest(request.ComponentName, component.Name))
                .Map(response => new ComponentWithSimilarity(component, response));
    }

    private static SimilaritiesFound<TComponent> SimilaritiesFound(
        IEnumerable<ComponentWithSimilarity> componentWithSimilarities
    )
    {
        var similarComponents = componentWithSimilarities
            .OrderByDescending(x => x.WordSimilarityResponse.Similarity.Coefficient)
            .Select(x => x.Component);
        return new SimilaritiesFound<TComponent>(similarComponents);
    }

    private sealed record ComponentWithSimilarity(TComponent Component, WordSimilarityResponse WordSimilarityResponse);
}
