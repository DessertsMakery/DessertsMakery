using DessertsMakery.Persistence.Models.Cakes;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class CakePricing : Entity
{
    public decimal Price { get; set; }

    public long CakeFamilyWeightId { get; set; }
    public CakeFamilyWeight CakeFamilyWeight { get; set; } = null!;
}
