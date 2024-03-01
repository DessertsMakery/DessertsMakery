using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Persistence.Database.Seeding;

internal static class DependencyInjectionExtensions
{
    private static readonly Type SeederMarker = typeof(IModelSeeder);

    internal static IServiceCollection AddSeeding(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.TryAddTransient<IEntitySeeder, EntitySeeder>();
        services.TryAddModelSeeding(assemblies);
        services.TryAddTransient<IDatabaseSeeder, DatabaseSeeder>();
        return services;
    }

    private static void TryAddModelSeeding(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        var types = assemblies
            .SelectMany(x => x.DefinedTypes)
            .Where(x => x is { IsAbstract: false, IsClass: true } && x.IsAssignableTo(SeederMarker))
            .ToArray();
        foreach (var type in types)
        {
            services.TryAddTransient(SeederMarker, type);
        }
    }
}
