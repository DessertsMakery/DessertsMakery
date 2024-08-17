using DessertsMakery.Common.Persistence.Mongo;

namespace DessertsMakery.Essentials.Persistence.Entities;

public sealed class Component : MongoEntity
{
    public string Name { get; set; } = null!;
    public Measuring Measuring { get; set; } = null!;
    public ComponentType ComponentType { get; set; } = null!;
    public ComponentParent? ComponentParent { get; set; }
}
