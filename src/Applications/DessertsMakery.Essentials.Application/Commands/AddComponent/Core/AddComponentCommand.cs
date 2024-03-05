using DessertsMakery.Persistence.Models.Essentials;
using MediatR;
using OneOf;
using Measuring = DessertsMakery.Contracts.Enums.Measuring;

namespace DessertsMakery.Essentials.Application.Commands.AddComponent.Core;

public abstract record AddComponentCommand<TComponent>(string ComponentName, Measuring Measuring, Guid? ParentGuid)
    : IRequest<OneOf<TComponent, SimilaritiesFound<TComponent>>>
    where TComponent : Component;
