using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class MeasuringConfiguration : IEntityTypeConfiguration<Measuring>
{
    public void Configure(EntityTypeBuilder<Measuring> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.ConsumablePackagings).WithOne(x => x.Measuring);
        builder.HasMany(x => x.RecipeIngredients).WithOne(x => x.Measuring);
        builder.HasMany(x => x.DessertWeights).WithOne(x => x.Measuring);
    }
}
