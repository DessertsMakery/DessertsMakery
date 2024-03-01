namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class ComponentMeasuringConversion : Entity
{
    public long ComponentId { get; set; }
    public Component Component { get; set; } = null!;

    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;

    public decimal Value { get; set; }
}
