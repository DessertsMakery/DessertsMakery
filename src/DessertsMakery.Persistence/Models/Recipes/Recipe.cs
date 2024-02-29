using DessertsMakery.Persistence.Models.Desserts;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class Recipe : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<RecipeDescriptionItem> RecipeDescriptionItems { get; set; } = new List<RecipeDescriptionItem>();
    public ICollection<DessertTemplateRecipe> DessertTemplateRecipes { get; set; } = new List<DessertTemplateRecipe>();
}
