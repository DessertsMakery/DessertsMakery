using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertWeightConfiguration : IEntityTypeConfiguration<DessertWeight>
{
    public void Configure(EntityTypeBuilder<DessertWeight> builder)
    {
        builder.HasMany(x => x.DessertTemplates).WithOne(x => x.DessertWeight);
        builder.HasMany(x => x.DessertFamilyWeights).WithOne(x => x.DessertWeight);
    }
}
