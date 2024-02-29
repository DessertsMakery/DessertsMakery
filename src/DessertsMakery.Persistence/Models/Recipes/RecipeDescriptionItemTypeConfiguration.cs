using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Recipes;

public sealed class RecipeDescriptionItemTypeConfiguration : IEntityTypeConfiguration<RecipeDescriptionItemType>
{
    public void Configure(EntityTypeBuilder<RecipeDescriptionItemType> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.RecipeDescriptionItems).WithOne(x => x.RecipeDescriptionItemType);
    }
}
