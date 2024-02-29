using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

internal sealed class ConsumablePackagingPriceConfiguration : BaseEntityTypeConfiguration<ConsumablePackagingPrice>
{
    protected override void Configure(EntityTypeBuilder<ConsumablePackagingPrice> builder)
    {
        builder.HasMany(x => x.PurchaseItems).WithOne(x => x.ConsumablePackagingPrice);
    }
}
