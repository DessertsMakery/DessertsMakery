using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Orders;

public sealed class OrderItemDetailsImageConfiguration : IEntityTypeConfiguration<OrderItemDetailsImage>
{
    public void Configure(EntityTypeBuilder<OrderItemDetailsImage> builder)
    {
        throw new NotImplementedException();
    }
}
