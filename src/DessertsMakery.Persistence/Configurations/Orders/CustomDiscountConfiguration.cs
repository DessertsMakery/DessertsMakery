using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Orders;

public sealed class CustomDiscountConfiguration : IEntityTypeConfiguration<CustomDiscount>
{
    public void Configure(EntityTypeBuilder<CustomDiscount> builder)
    {
        throw new NotImplementedException();
    }
}
