using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Utilities.Callbacks;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddTelegramCallbackUtilities(this IServiceCollection services)
    {
        services.TryAddTransient<ITelegramCallbackSerializer, TelegramCallbackSerializer>();
        services.TryAddTransient<ITelegramCallbackButtonCreator, TelegramCallbackButtonCreator>();
        return services;
    }
}
