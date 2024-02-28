namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeDescriptionItemType : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<RecipeDescriptionItem> RecipeDescriptionItems { get; set; } = new List<RecipeDescriptionItem>();
}
