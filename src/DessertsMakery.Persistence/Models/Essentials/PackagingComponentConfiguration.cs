using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class PackagingComponentConfiguration : IEntityTypeConfiguration<PackagingComponent>
{
    public void Configure(EntityTypeBuilder<PackagingComponent> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Consumables);
        builder.HasMany(x => x.OrderItemDetailPackagingComponents).WithOne(x => x.PackagingComponent);
    }
}
