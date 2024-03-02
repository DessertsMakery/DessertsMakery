using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Repositories.Components;

public interface IWriteOnlyComponentRepository
{
    ValueTask CreateAsync<TComponent>(TComponent component, CancellationToken token = default)
        where TComponent : Component;

    ValueTask UpdateAsync<TComponent>(
        Guid externalId,
        Action<TComponent> modification,
        CancellationToken token = default
    )
        where TComponent : Component;

    ValueTask DeleteAsync(Guid externalId, bool isHardDelete = false, CancellationToken token = default);
}
