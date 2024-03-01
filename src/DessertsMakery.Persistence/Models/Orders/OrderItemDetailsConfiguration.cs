using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class OrderItemDetailsConfiguration : BaseEntityTypeConfiguration<OrderItemDetails>
{
    protected override void Configure(EntityTypeBuilder<OrderItemDetails> builder)
    {
        builder.HasOne(x => x.CustomPrice).WithOne(x => x.OrderItemDetails);
        builder.HasOne(x => x.CustomDiscount).WithOne(x => x.OrderItemDetails);
        builder.HasMany(x => x.OrderItemDetailsImages).WithOne(x => x.OrderItemDetails);
        builder.HasMany(x => x.Additions).WithOne(x => x.OrderItemDetails);
        builder.HasMany(x => x.PackagingComponents).WithOne(x => x.OrderItemDetails);
    }
}
