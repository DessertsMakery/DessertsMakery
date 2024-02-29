using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeDescriptionItemConfiguration : IEntityTypeConfiguration<RecipeDescriptionItem>
{
    public void Configure(EntityTypeBuilder<RecipeDescriptionItem> builder)
    {
        builder.HasIndex(x => new { x.RecipeId, x.Order }).IsUnique();
    }
}
