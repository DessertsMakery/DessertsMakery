using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeFamilyWeightConfiguration : IEntityTypeConfiguration<CakeFamilyWeight>
{
    public void Configure(EntityTypeBuilder<CakeFamilyWeight> builder)
    {
        throw new NotImplementedException();
    }
}
