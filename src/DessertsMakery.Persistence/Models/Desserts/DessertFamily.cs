namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertFamily : Entity
{
    public string Name { get; set; } = null!;

    public long? ParentId { get; set; }
    public DessertFamily? Parent { get; set; }

    public ICollection<DessertFamily> Children { get; set; } = new List<DessertFamily>();
    public ICollection<DessertTemplate> DessertTemplates { get; set; } = new List<DessertTemplate>();
    public ICollection<DessertFamilyWeight> DessertFamilyWeights { get; set; } = new List<DessertFamilyWeight>();
}
