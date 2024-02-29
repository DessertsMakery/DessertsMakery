using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailsConfiguration : IEntityTypeConfiguration<OrderItemDetails>
{
    public void Configure(EntityTypeBuilder<OrderItemDetails> builder)
    {
        builder.HasOne(x => x.CustomPrice).WithOne(x => x.OrderItemDetails);
        builder.HasOne(x => x.CustomDiscount).WithOne(x => x.OrderItemDetails);
        builder.HasMany(x => x.OrderItemDetailsImages).WithOne(x => x.OrderItemDetails);
    }
}
