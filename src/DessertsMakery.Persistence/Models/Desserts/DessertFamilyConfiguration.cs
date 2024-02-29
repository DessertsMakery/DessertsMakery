using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertFamilyConfiguration : IEntityTypeConfiguration<DessertFamily>
{
    public void Configure(EntityTypeBuilder<DessertFamily> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Children).WithOne(x => x.Parent);
        builder.HasMany(x => x.DessertTemplates).WithOne(x => x.DessertFamily);
        builder.HasMany(x => x.DessertFamilyWeights).WithOne(x => x.DessertFamily);
    }
}
