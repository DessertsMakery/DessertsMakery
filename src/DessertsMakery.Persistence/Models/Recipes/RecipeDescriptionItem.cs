namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeDescriptionItem : Entity
{
    public string Text { get; set; } = null!;
    public int Order { get; set; }

    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public long RecipeDescriptionItemTypeId { get; set; }
    public RecipeDescriptionItemType RecipeDescriptionItemType { get; set; } = null!;
}
