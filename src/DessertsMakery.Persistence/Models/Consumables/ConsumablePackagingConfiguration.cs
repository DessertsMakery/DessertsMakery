using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingConfiguration : IEntityTypeConfiguration<ConsumablePackaging>
{
    public void Configure(EntityTypeBuilder<ConsumablePackaging> builder)
    {
        throw new NotImplementedException();
    }
}
