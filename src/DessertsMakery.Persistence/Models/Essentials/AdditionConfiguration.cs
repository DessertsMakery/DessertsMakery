using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Essentials;

internal sealed class AdditionConfiguration : BaseEntityTypeConfiguration<Addition>
{
    protected override void Configure(EntityTypeBuilder<Addition> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Consumables);
        builder.HasMany(x => x.OrderItemDetailsAdditions).WithOne(x => x.Addition);
    }
}
