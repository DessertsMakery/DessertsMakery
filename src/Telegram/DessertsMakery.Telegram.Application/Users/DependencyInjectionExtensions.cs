using DessertsMakery.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Users;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddTelegramUsers(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddSingleton<IUserMenuState, UserMenuState>();
        return services.AddMemoryCache().AddConfiguration<UserConfiguration>(configuration);
    }
}
