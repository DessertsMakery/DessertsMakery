namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipePartIngredient : Entity
{
    public long RecipePartId { get; set; }
    public RecipePart RecipePart { get; set; } = null!;

    public long IngredientNameId { get; set; }
    public IngredientName IngredientName { get; set; } = null!;

    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;
}
