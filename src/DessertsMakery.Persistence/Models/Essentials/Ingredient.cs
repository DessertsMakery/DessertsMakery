using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class Ingredient : Component
{
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
