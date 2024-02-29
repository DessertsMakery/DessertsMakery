using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertTemplateConfiguration : IEntityTypeConfiguration<DessertTemplate>
{
    public void Configure(EntityTypeBuilder<DessertTemplate> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.OrderItems).WithOne(x => x.DessertTemplate);
        builder.HasMany(x => x.DessertTemplateRecipes).WithOne(x => x.DessertTemplate);
    }
}
