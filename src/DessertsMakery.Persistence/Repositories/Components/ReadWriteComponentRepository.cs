using System.Linq.Expressions;
using DessertsMakery.Common.Wrappers;
using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Persistence.Database.Seeding;
using DessertsMakery.Persistence.Models.Essentials;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Repositories.Components;

internal sealed class ReadWriteComponentRepository : IReadWriteComponentRepository, IRepository
{
    private readonly IEssentialTables _essentialTables;
    private readonly IEntitySeeder _entitySeeder;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ReadWriteComponentRepository(
        IEssentialTables essentialTables,
        IEntitySeeder entitySeeder,
        IDateTimeProvider dateTimeProvider
    )
    {
        _essentialTables = essentialTables;
        _entitySeeder = entitySeeder;
        _dateTimeProvider = dateTimeProvider;
    }

    #region Get With Filtering

    public async Task<IReadOnlyCollection<Component>> GetComponentsAsync(
        Expression<Func<Component, bool>>? filter = null,
        CancellationToken token = default
    ) => await GetComponentRowsAsync(_essentialTables.Components, filter, token);

    public async Task<IReadOnlyCollection<Ingredient>> GetIngredientsAsync(
        Expression<Func<Ingredient, bool>>? filter = null,
        CancellationToken token = default
    ) => await GetComponentRowsAsync(_essentialTables.Ingredients, filter, token);

    public async Task<IReadOnlyCollection<Addition>> GetAdditionsAsync(
        Expression<Func<Addition, bool>>? filter = null,
        CancellationToken token = default
    ) => await GetComponentRowsAsync(_essentialTables.Additions, filter, token);

    public async Task<IReadOnlyCollection<PackagingComponent>> GetPackagingComponentsAsync(
        Expression<Func<PackagingComponent, bool>>? filter = null,
        CancellationToken token = default
    ) => await GetComponentRowsAsync(_essentialTables.PackagingComponents, filter, token);

    #endregion

    #region Get By Id

    public Task<Component?> GetComponentByIdAsync(Guid externalId, CancellationToken token = default) =>
        GetComponentByIdAsync(_essentialTables.Components, externalId, token);

    public Task<Ingredient?> GetIngredientByIdAsync(Guid externalId, CancellationToken token = default) =>
        GetComponentByIdAsync(_essentialTables.Ingredients, externalId, token);

    public Task<Addition?> GetAdditionByIdAsync(Guid externalId, CancellationToken token = default) =>
        GetComponentByIdAsync(_essentialTables.Additions, externalId, token);

    public Task<PackagingComponent?> GetPackagingComponentByIdAsync(
        Guid externalId,
        CancellationToken token = default
    ) => GetComponentByIdAsync(_essentialTables.PackagingComponents, externalId, token);

    #endregion

    #region Create

    public async ValueTask<TComponent> CreateAsync<TComponent>(TComponent component, CancellationToken token = default)
        where TComponent : Component
    {
        _entitySeeder.Seed(component);
        var entry = await _essentialTables.Components.AddAsync(component, token);
        return (TComponent)entry.Entity;
    }

    #endregion

    #region Update

    public async ValueTask UpdateAsync<TComponent>(
        Guid externalId,
        Action<TComponent> modification,
        CancellationToken token = default
    )
        where TComponent : Component
    {
        var table = _essentialTables.Components;
        var component = await GetComponentByIdAsync(table, externalId, token);
        var concrete = ConvertOrThrowIfNotCorrectComponentType<TComponent>(externalId, component);

        modification(concrete);
        concrete.ModifiedAt = _dateTimeProvider.GetUtcNow();
        table.Update(concrete);
    }

    #endregion

    #region Delete

    public async ValueTask DeleteAsync(Guid externalId, bool isHardDelete = false, CancellationToken token = default)
    {
        if (isHardDelete)
        {
            var table = _essentialTables.Components;
            var component = await GetComponentByIdAsync(table, externalId, token);
            ThrowIfComponentIsNull(externalId, component);
            _essentialTables.Components.Remove(component!);
            return;
        }

        await UpdateAsync<Component>(externalId, component => component.IsDeleted = true, token);
    }

    #endregion

    #region Helpers

    private static Task<TComponent[]> GetComponentRowsAsync<TComponent>(
        DbSet<TComponent> table,
        Expression<Func<TComponent, bool>>? filter,
        CancellationToken token
    )
        where TComponent : Component
    {
        var queryable = table.AsQueryable();
        if (filter is not null)
        {
            queryable = queryable.Where(filter);
        }

        return queryable.ToArrayAsync(token);
    }

    private static Task<TComponent?> GetComponentByIdAsync<TComponent>(
        DbSet<TComponent> table,
        Guid externalId,
        CancellationToken token
    )
        where TComponent : Component
    {
        return table.AsQueryable().FirstOrDefaultAsync(x => x.ExternalId == externalId, token);
    }

    private static TComponent ConvertOrThrowIfNotCorrectComponentType<TComponent>(Guid externalId, Component? component)
        where TComponent : Component
    {
        ThrowIfComponentIsNull(externalId, component);

        if (component is not TComponent concrete)
        {
            throw new InvalidOperationException(
                $"Requested component by external id: `{externalId}` is not of type `{typeof(TComponent)}`"
            );
        }

        return concrete;
    }

    private static void ThrowIfComponentIsNull(Guid externalId, Component? component)
    {
        if (component is null)
        {
            throw new InvalidOperationException($"Requested component by external id: `{externalId}` is not found");
        }
    }

    #endregion
}
