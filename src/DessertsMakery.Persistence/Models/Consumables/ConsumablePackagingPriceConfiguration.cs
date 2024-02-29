using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingPriceConfiguration : IEntityTypeConfiguration<ConsumablePackagingPrice>
{
    public void Configure(EntityTypeBuilder<ConsumablePackagingPrice> builder)
    {
        throw new NotImplementedException();
    }
}
