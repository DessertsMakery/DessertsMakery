using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeIngredient : Entity
{
    public string? Name { get; set; }

    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public long IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;

    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;
}
