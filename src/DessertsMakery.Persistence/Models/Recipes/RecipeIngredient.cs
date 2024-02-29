using DessertsMakery.Persistence.Configurations;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeIngredient : Entity
{
    public long RecipePartId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public long IngredientNameId { get; set; }
    public IngredientName IngredientName { get; set; } = null!;

    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;
}
