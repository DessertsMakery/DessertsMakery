using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Desserts;
using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class Measuring : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<Component> Components { get; set; } = new List<Component>();
    public ICollection<ComponentMeasuringConversion> ComponentMeasuringConversions { get; set; } =
        new List<ComponentMeasuringConversion>();
    public ICollection<ConsumablePackaging> ConsumablePackagings { get; set; } = new List<ConsumablePackaging>();
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<DessertWeight> DessertWeights { get; set; } = new List<DessertWeight>();
}
