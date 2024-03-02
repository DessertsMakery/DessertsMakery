using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Common.Algorithms;

public static class DependencyInjectionExtensions
{
    private static readonly Type AlgorithmMarker = typeof(IAlgorithm);
    private static readonly Assembly ThisAssembly = AlgorithmMarker.Assembly;

    public static IServiceCollection AddAlgorithms(this IServiceCollection services)
    {
        var marker = new[] { AlgorithmMarker };
        var types = ThisAssembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(AlgorithmMarker));
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
