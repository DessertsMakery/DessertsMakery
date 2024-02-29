using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

internal sealed class DessertFamilyConfiguration : BaseEntityTypeConfiguration<DessertFamily>
{
    protected override void Configure(EntityTypeBuilder<DessertFamily> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Children).WithOne(x => x.Parent);
        builder.HasMany(x => x.DessertFamilyWeights).WithOne(x => x.DessertFamily);
    }
}
