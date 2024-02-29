using DessertsMakery.Persistence.Models.Consumables;

namespace DessertsMakery.Persistence.Models.Purchases;

public sealed class PurchaseItem : Entity
{
    public long PurchaseId { get; set; }
    public Purchase Purchase { get; set; } = null!;

    public long ConsumablePackagingPriceId { get; set; }
    public ConsumablePackagingPrice ConsumablePackagingPrice { get; set; } = null!;

    public int Quantity { get; set; }
}
