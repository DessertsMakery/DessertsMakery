using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Essentials;

internal sealed class ComponentConfiguration : BaseEntityTypeConfiguration<Component>
{
    protected override void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder
            .HasDiscriminator<string>("ComponentType")
            .HasValue<Addition>(nameof(Addition))
            .HasValue<Ingredient>(nameof(Ingredient))
            .HasValue<PackagingComponent>(nameof(PackagingComponent));
        builder.HasMany(x => x.ComponentMeasuringConversions).WithOne(x => x.Component);
        builder.HasMany(x => x.Consumables).WithOne(x => x.Component);
        builder.HasMany(x => x.ComponentMeasuringConversions).WithOne(x => x.Component);
        builder.HasMany(x => x.RecipeIngredients).WithOne(x => x.Ingredient);
        builder.HasMany(x => x.OrderItemDetailsAdditions).WithOne(x => x.Addition);
        builder.HasMany(x => x.OrderItemDetailPackagingComponents).WithOne(x => x.PackagingComponent);
    }
}
