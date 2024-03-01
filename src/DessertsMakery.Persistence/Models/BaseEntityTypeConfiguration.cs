using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models;

internal abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.InternalId);
        builder.HasIndex(x => x.ExternalId).IsUnique();
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("DATE('now')");
        builder.Property(x => x.ModifiedAt).HasDefaultValueSql("DATE('now')");

        Configure(builder);
    }

    protected virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
}
