using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Users;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddTelegramUsers(this IServiceCollection services)
    {
        services.TryAddScoped<ITelegramModeratorMenuState, TelegramModeratorMenuState>();
        services.TryDecorate<ITelegramModeratorMenuState, TelegramModeratorMenuStateCacheProxy>();
        return services.AddMemoryCache();
    }
}
