using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Recipes;

public sealed class RecipeConfiguration : IEntityTypeConfiguration<RecipeConfiguration>
{
    public void Configure(EntityTypeBuilder<RecipeConfiguration> builder)
    {
        throw new NotImplementedException();
    }
}
