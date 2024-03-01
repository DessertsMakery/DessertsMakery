using EntityType = DessertsMakery.Persistence.Models.Essentials.Measuring;
using EnumType = DessertsMakery.Contracts.Enums.Measuring;

namespace DessertsMakery.Persistence.Database.Seeding.Enums;

internal sealed class MeasuringSeeder : EnumToEntitySeeder<EnumType, EntityType>
{
    public MeasuringSeeder(IEntitySeeder entitySeeder)
        : base(entitySeeder) { }

    protected override EntityType Map(EnumType @enum) => new() { InternalId = @enum.Value, Name = @enum.Name };
}
