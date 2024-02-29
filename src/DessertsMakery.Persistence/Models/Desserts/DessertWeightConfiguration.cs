using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

internal sealed class DessertWeightConfiguration : BaseEntityTypeConfiguration<DessertWeight>
{
    protected override void Configure(EntityTypeBuilder<DessertWeight> builder)
    {
        builder.HasMany(x => x.DessertFamilyWeights).WithOne(x => x.DessertWeight);
    }
}
