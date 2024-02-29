using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Purchases;

public sealed class PurchaseConfiguration : IEntityTypeConfiguration<PurchaseConfiguration>
{
    public void Configure(EntityTypeBuilder<PurchaseConfiguration> builder)
    {
        throw new NotImplementedException();
    }
}
