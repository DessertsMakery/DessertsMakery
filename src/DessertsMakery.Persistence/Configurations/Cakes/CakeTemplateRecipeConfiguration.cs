using DessertsMakery.Persistence.Models.Cakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Cakes;

public sealed class CakeTemplateRecipeConfiguration : IEntityTypeConfiguration<CakeTemplateRecipe>
{
    public void Configure(EntityTypeBuilder<CakeTemplateRecipe> builder)
    {
        throw new NotImplementedException();
    }
}
