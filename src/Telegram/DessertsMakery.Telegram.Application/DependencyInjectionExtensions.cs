using System.Reflection;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Utilities;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Telegram.Application;

public static class DependencyInjectionExtensions
{
    private static readonly Assembly ThisAssembly = typeof(DependencyInjectionExtensions).Assembly;

    public static IServiceCollection AddTelegramApplication(this IServiceCollection services)
    {
        return services
            .AddTelegramUtilities()
            .AddTelegramMenu()
            .AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(ThisAssembly);
                x.NotificationPublisher = new TaskWhenAllPublisher();
            });
    }
}
