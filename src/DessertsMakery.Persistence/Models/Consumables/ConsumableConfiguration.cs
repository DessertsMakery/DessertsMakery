using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

internal sealed class ConsumableConfiguration : BaseEntityTypeConfiguration<Consumable>
{
    protected override void Configure(EntityTypeBuilder<Consumable> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.ConsumablePackagings).WithOne(x => x.Consumable);
    }
}
