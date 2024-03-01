using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Recipes;

internal sealed class RecipeComponentConfiguration : BaseEntityTypeConfiguration<RecipeIngredient>
{
    protected override void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasOne(x => x.Ingredient).WithMany(x => x.RecipeIngredients);
    }
}
