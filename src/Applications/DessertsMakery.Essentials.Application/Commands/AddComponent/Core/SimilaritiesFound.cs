using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Essentials.Application.Commands.AddComponent.Core;

internal sealed record SimilaritiesFound<TComponent>(IEnumerable<TComponent> Components)
    where TComponent : Component;
