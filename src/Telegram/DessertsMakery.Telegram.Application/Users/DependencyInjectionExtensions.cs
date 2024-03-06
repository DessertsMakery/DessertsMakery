using DessertsMakery.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Telegram.Application.Users;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddTelegramUsers(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddConfiguration<UserConfiguration>(configuration);
    }
}
