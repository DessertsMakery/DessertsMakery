using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Orders;
using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models.Essentials;

public abstract class Component : Entity
{
    public string Name { get; set; } = null!;

    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;
    public decimal? Proportion { get; set; }

    public long? ParentId { get; set; }
    public Component? Parent { get; set; }

    public ICollection<Component> Children { get; set; } = new List<Component>();
    public ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();
    public ICollection<ComponentMeasuringConversion> ComponentMeasuringConversions { get; set; } =
        new List<ComponentMeasuringConversion>();
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<OrderItemDetailsAddition> OrderItemDetailsAdditions { get; set; } =
        new List<OrderItemDetailsAddition>();
    public ICollection<OrderItemDetailPackagingComponent> OrderItemDetailPackagingComponents { get; set; } =
        new List<OrderItemDetailPackagingComponent>();
}
