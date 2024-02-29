using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.HasMany(x => x.Components).WithOne(x => x.ComponentType);
    }
}
