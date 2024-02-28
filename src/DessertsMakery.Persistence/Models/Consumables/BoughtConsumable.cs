namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class BoughtConsumable
{
    public long ConsumablePackagingPriceId { get; set; }
    public ConsumablePackagingPrice ConsumablePackagingPrice { get; set; } = null!;

    public int Quantity { get; set; }
}