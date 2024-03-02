using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Persistence.Repositories;

internal static class DependencyInjectionExtensions
{
    private static readonly Type MarkerType = typeof(IRepository);
    private static readonly Assembly ThisAssembly = MarkerType.Assembly;

    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        var markers = new[] { MarkerType };
        var types = ThisAssembly
            .DefinedTypes.Where(x => x is { IsClass: true, IsAbstract: false } && x.IsAssignableTo(MarkerType))
            .ToArray();

        foreach (var type in types)
        {
            foreach (var @interface in type.ImplementedInterfaces.Except(markers))
            {
                services.TryAddScoped(@interface, type);
            }
        }

        return services;
    }
}
