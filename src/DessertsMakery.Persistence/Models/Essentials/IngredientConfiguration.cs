using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Essentials;

internal sealed class IngredientConfiguration : BaseEntityTypeConfiguration<Ingredient>
{
    protected override void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Consumables);
        builder.HasMany(x => x.RecipeIngredients).WithOne(x => x.Ingredient);
    }
}
