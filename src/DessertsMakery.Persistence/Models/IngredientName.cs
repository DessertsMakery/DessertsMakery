using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models;

public sealed class IngredientName : Entity
{
    public string? Name { get; set; }

    public ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();

    public ICollection<RecipePartIngredient> RecipePartIngredients { get; set; } = new List<RecipePartIngredient>();
}
