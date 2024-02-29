namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertFamilyWeight : Entity
{
    public long DessertFamilyId { get; set; }
    public DessertFamily DessertFamily { get; set; } = null!;

    public long DessertWeightId { get; set; }
    public DessertWeight DessertWeight { get; set; } = null!;

    public ICollection<DessertPricing> DessertPricing { get; set; } = new List<DessertPricing>();
}
