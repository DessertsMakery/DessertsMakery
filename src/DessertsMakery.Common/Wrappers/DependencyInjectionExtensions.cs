using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Common.Wrappers;

public static class DependencyInjectionExtensions
{
    private static readonly Type WrapperMarker = typeof(IWrapper);
    private static readonly Assembly ThisAssembly = WrapperMarker.Assembly;

    public static IServiceCollection AddWrappers(this IServiceCollection services)
    {
        var marker = new[] { WrapperMarker };
        var types = ThisAssembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(WrapperMarker));
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
