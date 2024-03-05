using DessertsMakery.Application.Core.Services.WordSimilarity;
using DessertsMakery.Essentials.Application.Commands.AddComponent.Core;
using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Persistence.Models.Essentials;
using DessertsMakery.Persistence.Repositories.Components;

namespace DessertsMakery.Essentials.Application.Commands.AddComponent.Ingredients;

internal sealed class AddIngredientCommandHandler : AddComponentCommandHandler<AddIngredientCommand, Ingredient>
{
    public AddIngredientCommandHandler(
        IWordSimilarityChecker wordSimilarityChecker,
        IReadWriteComponentRepository componentRepository,
        IUnitOfWork unitOfWork
    )
        : base(wordSimilarityChecker, componentRepository, unitOfWork) { }

    protected override Task<IReadOnlyCollection<Ingredient>> GetAllComponentsAsync(CancellationToken token) =>
        ComponentRepository.GetIngredientsAsync(filter: null, token);

    protected override async Task<Ingredient> ComponentFromAsync(AddIngredientCommand command, CancellationToken token)
    {
        var (componentName, measuring, parentGuid) = command;
        Component? parent = null;
        if (parentGuid.HasValue)
        {
            parent = await ComponentRepository.GetIngredientByIdAsync(parentGuid.Value, token);
        }

        return new Ingredient
        {
            Name = componentName,
            MeasuringId = measuring.Value,
            Parent = parent
        };
    }
}
