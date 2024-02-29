using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailPackagingComponentConfiguration
    : IEntityTypeConfiguration<OrderItemDetailPackagingComponent>
{
    public void Configure(EntityTypeBuilder<OrderItemDetailPackagingComponent> builder) { }
}
