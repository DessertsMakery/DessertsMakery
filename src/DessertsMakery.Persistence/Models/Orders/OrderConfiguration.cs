using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class OrderConfiguration : BaseEntityTypeConfiguration<Order>
{
    protected override void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(x => x.OrderItems).WithOne(x => x.Order);
    }
}
