using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Purchases;

internal sealed class PurchaseConfiguration : BaseEntityTypeConfiguration<Purchase>
{
    protected override void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasMany(x => x.PurchaseItems).WithOne(x => x.Purchase);
    }
}
