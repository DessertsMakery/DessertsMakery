using DessertsMakery.Essentials.Application.Commands.AddComponent.Core;
using DessertsMakery.Persistence.Models.Essentials;
using Measuring = DessertsMakery.Contracts.Enums.Measuring;

namespace DessertsMakery.Essentials.Application.Commands.AddComponent.Ingredients;

internal sealed record AddIngredientCommand(string ComponentName, Measuring Measuring, Guid? ParentGuid)
    : AddComponentCommand<Ingredient>(ComponentName, Measuring, ParentGuid);
