using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Utilities.Localization;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddTelegramLocalizationUtilities(this IServiceCollection services)
    {
        services.TryAddTransient<ITelegramMessageLocalizer, EmptyTelegramMessageLocalizer>();
        return services;
    }
}
