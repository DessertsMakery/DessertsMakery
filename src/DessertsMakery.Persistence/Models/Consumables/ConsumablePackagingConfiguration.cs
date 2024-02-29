using DessertsMakery.Persistence.Models.Consumables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Consumables;

public sealed class ConsumablePackagingConfiguration : IEntityTypeConfiguration<ConsumablePackaging>
{
    public void Configure(EntityTypeBuilder<ConsumablePackaging> builder)
    {
        throw new NotImplementedException();
    }
}
