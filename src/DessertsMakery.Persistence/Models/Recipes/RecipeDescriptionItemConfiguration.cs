using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Recipes;

internal sealed class RecipeDescriptionItemConfiguration : BaseEntityTypeConfiguration<RecipeDescriptionItem>
{
    protected override void Configure(EntityTypeBuilder<RecipeDescriptionItem> builder)
    {
        builder.HasIndex(x => new { x.RecipeId, x.Order }).IsUnique();
    }
}
