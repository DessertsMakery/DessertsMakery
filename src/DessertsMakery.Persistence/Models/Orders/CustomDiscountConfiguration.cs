using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class CustomDiscountConfiguration : BaseEntityTypeConfiguration<CustomDiscount>
{
    protected override void Configure(EntityTypeBuilder<CustomDiscount> builder)
    {
        builder.Property(x => x.Reason).IsRequired();
    }
}
