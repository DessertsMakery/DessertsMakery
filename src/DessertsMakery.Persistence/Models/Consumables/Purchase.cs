namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class Purchase : Entity
{
    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}
