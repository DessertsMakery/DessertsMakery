using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class CakePricingConfiguration : IEntityTypeConfiguration<CakePricing>
{
    public void Configure(EntityTypeBuilder<CakePricing> builder)
    {
        throw new NotImplementedException();
    }
}
