using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models;

public sealed class MeasuringConfiguration : IEntityTypeConfiguration<Measuring>
{
    public void Configure(EntityTypeBuilder<Measuring> builder)
    {
        throw new NotImplementedException();
    }
}
