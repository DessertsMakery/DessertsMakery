namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeDescription : Entity
{
    public Recipe Recipe { get; set; } = null!;

    public ICollection<RecipeDescriptionItem> RecipeDescriptionItems { get; set; } = new List<RecipeDescriptionItem>();
}
