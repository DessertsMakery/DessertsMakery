using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

internal sealed class DessertFamilyWeightConfiguration : BaseEntityTypeConfiguration<DessertFamilyWeight>
{
    protected override void Configure(EntityTypeBuilder<DessertFamilyWeight> builder)
    {
        builder.HasMany(x => x.DessertPricing).WithOne(x => x.DessertFamilyWeight);
        builder.HasMany(x => x.DessertTemplates).WithOne(x => x.DessertFamilyWeight);
    }
}
