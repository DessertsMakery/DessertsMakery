using DessertsMakery.Persistence.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Recipes;

public sealed class RecipeDescriptionItemTypeConfiguration : IEntityTypeConfiguration<RecipeDescriptionItemType>
{
    public void Configure(EntityTypeBuilder<RecipeDescriptionItemType> builder)
    {
        throw new NotImplementedException();
    }
}
