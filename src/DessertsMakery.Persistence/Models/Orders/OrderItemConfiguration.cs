using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class OrderItemConfiguration : BaseEntityTypeConfiguration<OrderItem>
{
    protected override void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasOne(x => x.OrderItemDetails).WithOne(x => x.OrderItem);
    }
}
