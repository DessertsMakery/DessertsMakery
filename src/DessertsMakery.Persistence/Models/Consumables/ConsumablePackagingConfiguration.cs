using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingConfiguration : IEntityTypeConfiguration<ConsumablePackaging>
{
    public void Configure(EntityTypeBuilder<ConsumablePackaging> builder)
    {
        builder.HasMany(x => x.Prices).WithOne(x => x.ConsumablePackaging);
        builder.HasMany(x => x.Images).WithOne(x => x.ConsumablePackaging);
    }
}
