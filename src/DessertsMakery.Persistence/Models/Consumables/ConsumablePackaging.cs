namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackaging : Entity
{
    public long ConsumableId { get; set; }
    public Consumable Consumable { get; set; } = null!;

    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;

    public ICollection<ConsumablePackagingPrice> Prices { get; set; } = new List<ConsumablePackagingPrice>();

    public ICollection<ConsumablePackagingImage> Images { get; set; } = new List<ConsumablePackagingImage>();
}
