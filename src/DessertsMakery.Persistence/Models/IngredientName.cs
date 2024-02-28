using DessertsMakery.Persistence.Models.Consumables;

namespace DessertsMakery.Persistence.Models;

public sealed class IngredientName : Entity
{
    public string? Name { get; set; }

    public ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();
}