using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Recipes;

internal sealed class RecipeConfiguration : BaseEntityTypeConfiguration<Recipe>
{
    protected override void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.RecipeDescriptionItems).WithOne(x => x.Recipe);
        builder.HasMany(x => x.RecipeIngredients).WithOne(x => x.Recipe);
        builder.HasMany(x => x.DessertTemplateRecipes).WithOne(x => x.Recipe);
    }
}
