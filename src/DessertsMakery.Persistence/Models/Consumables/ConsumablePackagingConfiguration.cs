using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

internal sealed class ConsumablePackagingConfiguration : BaseEntityTypeConfiguration<ConsumablePackaging>
{
    protected override void Configure(EntityTypeBuilder<ConsumablePackaging> builder)
    {
        builder.HasMany(x => x.Prices).WithOne(x => x.ConsumablePackaging);
        builder.HasMany(x => x.Images).WithOne(x => x.ConsumablePackaging);
    }
}
