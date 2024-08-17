using DessertsMakery.Common.Tests.Infrastructure.Sdk;
using DessertsMakery.Essentials.SDK.Components;
using DessertsMakery.Essentials.SDK.Components.Contracts;
using FluentAssertions;
using FluentAssertions.Execution;

namespace DessertsMakery.Essentials.SDK.Integration.Tests.Components;

public sealed class ComponentServiceTests(SdkBuilder sdkBuilder) : IAsyncLifetime
{
    private IComponentService _sut = null!;

    public async Task InitializeAsync() => _sut = await sdkBuilder.ResolveAsync<IComponentService>();

    [Fact]
    public async Task CreateAsync_Always_ShouldCreateRecordInMongo()
    {
        // Arrange
        var createComponentDto = new CreateComponentDto("Milk", "Mass", "Consumable");

        // Act
        var actual = await _sut.CreateAsync(createComponentDto);

        // Assert
        using (new AssertionScope())
        {
            actual
                .Should()
                .BeEquivalentTo(
                    new
                    {
                        createComponentDto.Name,
                        createComponentDto.Measuring,
                        createComponentDto.ComponentType,
                        createComponentDto.ParentId,
                        createComponentDto.Proportion
                    }
                );
        }
    }

    [Fact]
    public async Task GetByNameAsync_WhenFewEntries_ShouldReturnThem()
    {
        // Arrange
        await _sut.CreateAsync(new CreateComponentDto("Milk", "Mass", "Consumable"));
        await _sut.CreateAsync(new CreateComponentDto("Jam", "Mass", "Consumable"));
        await _sut.CreateAsync(new CreateComponentDto("Ham", "Mass", "Consumable"));

        // Act
        var actual = await _sut.TryGetBestMatchByNameAsync("Sam");

        // Assert
        using (new AssertionScope())
        {
            actual.Should().NotBeEmpty().And.HaveCount(2);
            actual.Select(x => x.Name).Should().Contain(["Jam", "Ham"]);
        }
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
