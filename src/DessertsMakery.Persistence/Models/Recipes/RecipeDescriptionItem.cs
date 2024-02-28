namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeDescriptionItem
{
    public string Text { get; set; } = null!;
    public int Order { get; set; }

    public long RecipeDescriptionId { get; set; }
    public RecipeDescription RecipeDescription { get; set; } = null!;

    public long RecipeDescriptionItemTypeId { get; set; }
    public RecipeDescriptionItemType RecipeDescriptionItemType { get; set; } = null!;
}
