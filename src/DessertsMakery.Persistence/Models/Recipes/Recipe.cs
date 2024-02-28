namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class Recipe : Entity
{
    public string Name { get; set; } = null!;

    public long? RecipeDescriptionId { get; set; }
    public RecipeDescription? RecipeDescription { get; set; }

    public ICollection<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();
}
