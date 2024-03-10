using System.Reflection;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Users;
using DessertsMakery.Telegram.Application.Utilities;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Telegram.Application;

public static class DependencyInjectionExtensions
{
    private static readonly Assembly ThisAssembly = typeof(DependencyInjectionExtensions).Assembly;

    public static IServiceCollection AddTelegramApplication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services
            .AddTelegramUtilities()
            .AddTelegramMenu()
            .AddTelegramUsers(configuration)
            .AddMediatR(x =>
            {
                x.NotificationPublisher = new TaskWhenAllPublisher();
                x.RegisterServicesFromAssembly(ThisAssembly);
            });
    }
}
