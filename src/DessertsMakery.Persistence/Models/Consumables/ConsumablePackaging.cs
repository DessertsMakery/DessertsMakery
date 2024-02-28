namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackaging
{
    public long ConsumableId { get; set; }
    public Consumable Consumable { get; set; } = null!;
    
    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;

    public ICollection<ConsumablePackagingPrice> ConsumablePackagingPrices { get; set; } =
        new List<ConsumablePackagingPrice>();
}