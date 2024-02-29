using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeFamilyWeight : Entity
{
    public long CakeFamilyId { get; set; }
    public CakeFamily CakeFamily { get; set; } = null!;

    public long CakeWeightId { get; set; }
    public CakeWeight CakeWeight { get; set; } = null!;

    public long CakePricingId { get; set; }
    public CakePricing CakePricing { get; set; } = null!;
}
