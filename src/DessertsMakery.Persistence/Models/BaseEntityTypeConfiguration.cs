using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace DessertsMakery.Persistence.Models;

internal abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.InternalId);
        builder.HasIndex(x => x.ExternalId).IsUnique();
        builder.Property(x => x.ExternalId).HasValueGenerator<GuidGenerator>();
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("DATE('now')");
        builder.Property(x => x.ModifiedAt).HasDefaultValueSql("DATE('now')");

        Configure(builder);
    }

    protected virtual void Configure(EntityTypeBuilder<TEntity> builder) { }

    public class GuidGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry) => Guid.NewGuid().ToString();

        public override bool GeneratesTemporaryValues => true;
    }
}
