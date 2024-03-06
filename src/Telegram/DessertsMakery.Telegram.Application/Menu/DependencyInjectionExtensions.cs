using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Menu;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddTelegramMenu(this IServiceCollection services)
    {
        var factory = new MenuFactory();
        var root = factory.Create();
        services.TryAddSingleton<IMenuRoot>(root);
        return services;
    }
}
