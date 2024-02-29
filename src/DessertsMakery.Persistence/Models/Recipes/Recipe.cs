using DessertsMakery.Persistence.Models.Cakes;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class Recipe : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<RecipeDescriptionItem> RecipeDescriptionItems { get; set; } = new List<RecipeDescriptionItem>();
    public ICollection<RecipeIngredient> RecipePartIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<CakeTemplateRecipe> CakeTemplateRecipes { get; set; } = new List<CakeTemplateRecipe>();
}
