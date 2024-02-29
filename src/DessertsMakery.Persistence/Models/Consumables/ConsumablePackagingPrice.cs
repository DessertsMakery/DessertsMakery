using DessertsMakery.Persistence.Models.Purchases;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingPrice : Entity
{
    public decimal Price { get; set; }
    public long ConsumablePackagingId { get; set; }
    public ConsumablePackaging ConsumablePackaging { get; set; } = null!;

    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}
