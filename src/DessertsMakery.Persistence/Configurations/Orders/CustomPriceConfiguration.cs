using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Orders;

public sealed class CustomPriceConfiguration : IEntityTypeConfiguration<CustomPrice>
{
    public void Configure(EntityTypeBuilder<CustomPrice> builder)
    {
        throw new NotImplementedException();
    }
}
