using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

internal sealed class DessertTemplateConfiguration : BaseEntityTypeConfiguration<DessertTemplate>
{
    protected override void Configure(EntityTypeBuilder<DessertTemplate> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.OrderItems).WithOne(x => x.DessertTemplate);
        builder.HasMany(x => x.DessertTemplateRecipes).WithOne(x => x.DessertTemplate);
    }
}
