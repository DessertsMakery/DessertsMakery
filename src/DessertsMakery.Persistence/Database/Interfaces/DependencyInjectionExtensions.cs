using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Persistence.Database.Interfaces;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddDatabaseInterfaces<TContext>(this IServiceCollection services)
        where TContext : notnull
    {
        var tablesMarker = typeof(ITables);
        var contextType = typeof(TContext);
        var tableInterfaces = contextType
            .GetInterfaces()
            .Where(x => x.IsAssignableTo(tablesMarker))
            .Except(new[] { tablesMarker });

        foreach (var tableInterface in tableInterfaces)
        {
            services.AddDatabaseInterface<TContext>(tableInterface);
        }

        return services;
    }

    private static void AddDatabaseInterface<TContext>(this IServiceCollection services, Type serviceType)
        where TContext : notnull =>
        services.TryAddScoped(serviceType, provider => provider.GetRequiredService<TContext>());
}
