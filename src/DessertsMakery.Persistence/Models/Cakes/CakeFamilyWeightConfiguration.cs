using DessertsMakery.Persistence.Models.Cakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Cakes;

public sealed class CakeFamilyWeightConfiguration : IEntityTypeConfiguration<CakeFamilyWeight>
{
    public void Configure(EntityTypeBuilder<CakeFamilyWeight> builder)
    {
        throw new NotImplementedException();
    }
}
