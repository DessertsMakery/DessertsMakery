using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class ConsumablePackagingImageConfiguration : IEntityTypeConfiguration<ConsumablePackagingImage>
{
    public void Configure(EntityTypeBuilder<ConsumablePackagingImage> builder) { }
}
