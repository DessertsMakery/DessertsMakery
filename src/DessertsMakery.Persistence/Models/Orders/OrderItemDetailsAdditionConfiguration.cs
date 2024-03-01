using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class OrderItemDetailsAdditionConfiguration : BaseEntityTypeConfiguration<OrderItemDetailsAddition>
{
    protected override void Configure(EntityTypeBuilder<OrderItemDetailsAddition> builder)
    {
        builder.HasOne(x => x.Addition).WithMany(x => x.OrderItemDetailsAdditions);
    }
}
