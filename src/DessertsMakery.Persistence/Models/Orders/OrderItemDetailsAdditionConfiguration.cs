using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailsAdditionConfiguration : IEntityTypeConfiguration<OrderItemDetailsAddition>
{
    public void Configure(EntityTypeBuilder<OrderItemDetailsAddition> builder) { }
}
