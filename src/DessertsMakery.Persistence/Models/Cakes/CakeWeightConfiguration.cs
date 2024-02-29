using DessertsMakery.Persistence.Models.Cakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Cakes;

public sealed class CakeWeightConfiguration : IEntityTypeConfiguration<CakeWeight>
{
    public void Configure(EntityTypeBuilder<CakeWeight> builder)
    {
        throw new NotImplementedException();
    }
}
