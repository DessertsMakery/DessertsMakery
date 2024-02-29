using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Customers;

internal sealed class CustomerConfiguration : BaseEntityTypeConfiguration<Customer>
{
    protected override void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(x => x.Username).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(200);
        builder.Property(x => x.Comment);
        builder.HasMany(x => x.Orders).WithOne(x => x.Customer);
    }
}
