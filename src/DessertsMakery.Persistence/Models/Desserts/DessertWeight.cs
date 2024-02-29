using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertWeight : Entity
{
    public decimal MeasuringValue { get; set; }
    public long MeasuringId { get; set; }
    public Measuring Measuring { get; set; } = null!;

    public ICollection<DessertFamilyWeight> DessertFamilyWeights { get; set; } = new List<DessertFamilyWeight>();
}
