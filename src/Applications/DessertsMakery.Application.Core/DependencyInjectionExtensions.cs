using DessertsMakery.Application.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Application.Core;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        return services.AddServices();
    }
}
