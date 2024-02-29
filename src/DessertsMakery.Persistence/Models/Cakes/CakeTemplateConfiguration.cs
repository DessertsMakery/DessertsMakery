using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeTemplateConfiguration : IEntityTypeConfiguration<CakeTemplate>
{
    public void Configure(EntityTypeBuilder<CakeTemplate> builder)
    {
        throw new NotImplementedException();
    }
}
