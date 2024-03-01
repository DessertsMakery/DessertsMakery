using EntityType = DessertsMakery.Persistence.Models.Recipes.RecipeDescriptionItemType;
using EnumType = DessertsMakery.Contracts.Enums.RecipeDescriptionItemType;

namespace DessertsMakery.Persistence.Database.Seeding.Enums;

internal sealed class RecipeDescriptionItemTypeSeeder : EnumToEntitySeeder<EnumType, EntityType>
{
    public RecipeDescriptionItemTypeSeeder(IEntitySeeder entitySeeder)
        : base(entitySeeder) { }

    protected override EntityType Map(EnumType @enum) => new() { InternalId = @enum.Value, Name = @enum.Name };
}
