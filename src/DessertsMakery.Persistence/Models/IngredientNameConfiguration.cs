using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models;

internal sealed class IngredientNameConfiguration : IEntityTypeConfiguration<IngredientName>
{
    public void Configure(EntityTypeBuilder<IngredientName> builder)
    {
        throw new NotImplementedException();
    }
}
