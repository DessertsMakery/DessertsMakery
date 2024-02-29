using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertTemplateRecipeConfiguration : IEntityTypeConfiguration<DessertTemplateRecipe>
{
    public void Configure(EntityTypeBuilder<DessertTemplateRecipe> builder) { }
}
