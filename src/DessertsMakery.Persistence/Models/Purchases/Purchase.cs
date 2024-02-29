namespace DessertsMakery.Persistence.Models.Purchases;

public sealed class Purchase : Entity
{
    public string? Comment { get; set; }

    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}
