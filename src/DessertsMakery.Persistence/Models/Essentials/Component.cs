using DessertsMakery.Persistence.Models.Consumables;

namespace DessertsMakery.Persistence.Models.Essentials;

public abstract class Component : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();
}
