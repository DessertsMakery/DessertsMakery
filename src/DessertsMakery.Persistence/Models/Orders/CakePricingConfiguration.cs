using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Orders;

public sealed class CakePricingConfiguration : IEntityTypeConfiguration<CakePricing>
{
    public void Configure(EntityTypeBuilder<CakePricing> builder)
    {
        throw new NotImplementedException();
    }
}
