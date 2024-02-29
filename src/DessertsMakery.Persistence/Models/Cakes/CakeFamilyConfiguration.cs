using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeFamilyConfiguration : IEntityTypeConfiguration<CakeFamily>
{
    public void Configure(EntityTypeBuilder<CakeFamily> builder)
    {
        throw new NotImplementedException();
    }
}
