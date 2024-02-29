using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

internal sealed class CustomPriceConfiguration : BaseEntityTypeConfiguration<CustomPrice>
{
    protected override void Configure(EntityTypeBuilder<CustomPrice> builder)
    {
        builder.Property(x => x.Reason).IsRequired();
    }
}
