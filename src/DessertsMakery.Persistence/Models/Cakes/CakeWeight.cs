using DessertsMakery.Persistence.Configurations;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeWeight : Entity
{
    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;

    public ICollection<CakeTemplate> CakeTemplates { get; set; } = new List<CakeTemplate>();
    public ICollection<CakeFamilyWeight> CakeFamilyWeights { get; set; } = new List<CakeFamilyWeight>();
}
