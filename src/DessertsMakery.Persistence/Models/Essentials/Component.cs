using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class Component : Entity
{
    public string Name { get; set; } = null!;

    public long ComponentTypeId { get; set; }
    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();
    public ICollection<RecipeIngredient> RecipePartIngredients { get; set; } = new List<RecipeIngredient>();
}
