using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Recipes;

internal sealed class RecipeDescriptionItemTypeConfiguration : BaseEntityTypeConfiguration<RecipeDescriptionItemType>
{
    protected override void Configure(EntityTypeBuilder<RecipeDescriptionItemType> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.RecipeDescriptionItems).WithOne(x => x.RecipeDescriptionItemType);
    }
}
