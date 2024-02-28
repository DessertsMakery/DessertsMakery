namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipePart : Entity
{
    public string Name { get; set; } = null!;

    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public ICollection<RecipePartIngredient> RecipePartIngredients { get; set; } = new List<RecipePartIngredient>();
}
