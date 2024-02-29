using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class CustomPriceConfiguration : IEntityTypeConfiguration<CustomPrice>
{
    public void Configure(EntityTypeBuilder<CustomPrice> builder)
    {
        builder.Property(x => x.Reason).IsRequired();
    }
}
