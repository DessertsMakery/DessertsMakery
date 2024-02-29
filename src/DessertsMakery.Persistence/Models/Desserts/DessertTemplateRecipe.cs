using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertTemplateRecipe : Entity
{
    public long DessertTemplateId { get; set; }
    public DessertTemplate DessertTemplate { get; set; } = null!;

    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public decimal Weight { get; set; }
}
