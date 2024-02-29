using DessertsMakery.Persistence.Models.Cakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Configurations.Cakes;

public sealed class CakeFamilyConfiguration : IEntityTypeConfiguration<CakeFamily>
{
    public void Configure(EntityTypeBuilder<CakeFamily> builder)
    {
        throw new NotImplementedException();
    }
}
