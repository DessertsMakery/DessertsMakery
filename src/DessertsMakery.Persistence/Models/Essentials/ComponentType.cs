namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class ComponentType : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<Component> Components { get; set; } = new List<Component>();
}
