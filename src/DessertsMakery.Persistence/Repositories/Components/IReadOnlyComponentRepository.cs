using System.Linq.Expressions;
using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Repositories.Components;

public interface IReadOnlyComponentRepository
{
    Task<IReadOnlyCollection<Component>> GetComponentsAsync(
        Expression<Func<Component, bool>>? filter = null,
        CancellationToken token = default
    );

    Task<IReadOnlyCollection<Ingredient>> GetIngredientsAsync(
        Expression<Func<Ingredient, bool>>? filter = null,
        CancellationToken token = default
    );

    Task<IReadOnlyCollection<Addition>> GetAdditionsAsync(
        Expression<Func<Addition, bool>>? filter = null,
        CancellationToken token = default
    );

    Task<IReadOnlyCollection<PackagingComponent>> GetPackagingComponentsAsync(
        Expression<Func<PackagingComponent, bool>>? filter = null,
        CancellationToken token = default
    );

    Task<Component?> GetComponentByIdAsync(Guid externalId, CancellationToken token = default);
    Task<Ingredient?> GetIngredientByIdAsync(Guid externalId, CancellationToken token = default);
    Task<Addition?> GetAdditionByIdAsync(Guid externalId, CancellationToken token = default);

    Task<PackagingComponent?> GetPackagingComponentByIdAsync(Guid externalId, CancellationToken token = default);
}
