namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeFamily : Entity
{
    public string Name { get; set; } = null!;

    public long? ParentId { get; set; }
    public CakeFamily? Parent { get; set; }

    public ICollection<CakeFamily> Children { get; set; } = new List<CakeFamily>();
    public ICollection<CakeTemplate> CakeTemplates { get; set; } = new List<CakeTemplate>();
    public ICollection<CakeFamilyWeight> CakeFamilyWeights { get; set; } = new List<CakeFamilyWeight>();
}
