namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertPricing : Entity
{
    public decimal Price { get; set; }

    public long DessertFamilyWeightId { get; set; }
    public DessertFamilyWeight DessertFamilyWeight { get; set; } = null!;
}
