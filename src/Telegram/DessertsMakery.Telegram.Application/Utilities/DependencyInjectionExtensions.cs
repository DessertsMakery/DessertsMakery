using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Utilities;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddTelegramUtilities(this IServiceCollection services)
    {
        services.TryAddTransient<IMenuMarkupBuilder, MenuMarkupBuilder>();
        return services;
    }
}
