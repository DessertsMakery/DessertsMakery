using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeIngredient : Entity
{
    public long RecipePartId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public long ComponentId { get; set; }
    public Component Component { get; set; } = null!;

    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;
}
