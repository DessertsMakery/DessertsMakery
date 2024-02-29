using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertFamilyWeightConfiguration : IEntityTypeConfiguration<DessertFamilyWeight>
{
    public void Configure(EntityTypeBuilder<DessertFamilyWeight> builder)
    {
        builder.HasMany(x => x.DessertPricing).WithOne(x => x.DessertFamilyWeight);
    }
}
