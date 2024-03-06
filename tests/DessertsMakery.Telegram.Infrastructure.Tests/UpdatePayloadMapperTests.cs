using FluentAssertions;
using FluentAssertions.Execution;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Infrastructure.Tests;

public sealed class UpdatePayloadMapperTests
{
    private readonly UpdatePayloadMapper _sut;

    public UpdatePayloadMapperTests()
    {
        _sut = new UpdatePayloadMapper();
    }

    [Theory]
    [MemberData(nameof(GetTestDataForAllPossibleStrategiesBasedOnUpdateTypeEnum))]
    public void Map_Always_ShouldHaveAllPossibleStrategiesBasedOnUpdateTypeEnum(Update update)
    {
        // Act
        var action = () => _sut.Map(update);

        // Assert
        using (new AssertionScope())
        {
            var value = action.Should().NotThrow().Which;
            value.Should().NotBeNull();
        }
    }

    public static IEnumerable<object[]> GetTestDataForAllPossibleStrategiesBasedOnUpdateTypeEnum()
    {
        var properties = typeof(Update)
            .GetProperties()
            .ExceptBy(new[] { nameof(Update.Id), nameof(Update.Type) }, x => x.Name)
            .ToArray();

        foreach (var property in properties)
        {
            var update = Activator.CreateInstance<Update>();
            property.SetValue(update, Activator.CreateInstance(property.PropertyType));

            yield return new object[] { update };
        }
    }
}
