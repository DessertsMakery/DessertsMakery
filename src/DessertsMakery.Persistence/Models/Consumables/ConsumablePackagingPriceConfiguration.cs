using DessertsMakery.Persistence.Models.Consumables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Consumables;

public sealed class ConsumablePackagingPriceConfiguration : IEntityTypeConfiguration<ConsumablePackagingPrice>
{
    public void Configure(EntityTypeBuilder<ConsumablePackagingPrice> builder)
    {
        throw new NotImplementedException();
    }
}
