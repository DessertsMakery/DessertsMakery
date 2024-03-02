using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Application.Core.Services;

internal static class DependencyInjectionExtensions
{
    private static readonly Type ServiceMarker = typeof(IService);
    private static readonly Assembly ThisAssembly = ServiceMarker.Assembly;

    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        var marker = new[] { ServiceMarker };
        var types = ThisAssembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(ServiceMarker));
        foreach (var type in types)
        {
            foreach (var @interface in type.ImplementedInterfaces.Except(marker))
            {
                services.TryAddTransient(@interface, type);
            }
        }

        return services;
    }
}
