using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Orders;

public sealed class OrderItemDetailsConfiguration : IEntityTypeConfiguration<OrderItemDetails>
{
    public void Configure(EntityTypeBuilder<OrderItemDetails> builder)
    {
        throw new NotImplementedException();
    }
}
