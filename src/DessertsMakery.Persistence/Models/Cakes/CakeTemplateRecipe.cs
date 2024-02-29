using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeTemplateRecipe : Entity
{
    public long CakeTemplateId { get; set; }
    public CakeTemplate CakeTemplate { get; set; } = null!;

    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public decimal Weight { get; set; }
}
