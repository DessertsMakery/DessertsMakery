using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertPricingConfiguration : IEntityTypeConfiguration<DessertPricing>
{
    public void Configure(EntityTypeBuilder<DessertPricing> builder) { }
}
