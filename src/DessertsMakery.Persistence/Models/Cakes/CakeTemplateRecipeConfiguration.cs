using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeTemplateRecipeConfiguration : IEntityTypeConfiguration<CakeTemplateRecipe>
{
    public void Configure(EntityTypeBuilder<CakeTemplateRecipe> builder)
    {
        throw new NotImplementedException();
    }
}
