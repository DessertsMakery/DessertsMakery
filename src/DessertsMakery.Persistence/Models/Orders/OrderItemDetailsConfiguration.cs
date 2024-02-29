using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailsConfiguration : IEntityTypeConfiguration<OrderItemDetails>
{
    public void Configure(EntityTypeBuilder<OrderItemDetails> builder)
    {
        throw new NotImplementedException();
    }
}
