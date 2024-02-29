using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingImageConfiguration
    : IEntityTypeConfiguration<ConsumablePackagingImageConfiguration>
{
    public void Configure(EntityTypeBuilder<ConsumablePackagingImageConfiguration> builder)
    {
        throw new NotImplementedException();
    }
}
