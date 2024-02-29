using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class CustomDiscountConfiguration : IEntityTypeConfiguration<CustomDiscount>
{
    public void Configure(EntityTypeBuilder<CustomDiscount> builder)
    {
        builder.Property(x => x.Reason).IsRequired();
    }
}
