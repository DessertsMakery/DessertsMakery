using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class OrderItemDetailPackagingComponentConfiguration
    : BaseEntityTypeConfiguration<OrderItemDetailPackagingComponent>
{
    protected override void Configure(EntityTypeBuilder<OrderItemDetailPackagingComponent> builder)
    {
        builder.HasOne(x => x.PackagingComponent).WithMany(x => x.OrderItemDetailPackagingComponents);
    }
}
