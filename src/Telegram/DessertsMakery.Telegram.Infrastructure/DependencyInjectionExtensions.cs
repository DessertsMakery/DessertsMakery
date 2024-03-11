using DessertsMakery.Common;
using DessertsMakery.Persistence;
using DessertsMakery.Telegram.Application.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace DessertsMakery.Telegram.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddTelegramInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.TryAddTransient<IUpdatePayloadMapper, UpdatePayloadMapper>();
        return services
            .AddPersistence(configuration)
            .TryAddAuthenticator()
            .AddTelegramOptions(configuration)
            .TryAddTelegramBotListener()
            .TryAddTelegramBotClient();
    }

    private static IServiceCollection TryAddAuthenticator(this IServiceCollection services)
    {
        services.TryAddSingleton<ITelegramAuthenticator, TelegramAuthenticator>();
        services.TryAddSingleton<ITelegramUserAccessor>(provider =>
            (ITelegramUserAccessor)provider.GetRequiredService<ITelegramAuthenticator>()
        );
        return services;
    }

    private static IServiceCollection AddTelegramOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddSingleton<TelegramBotClientOptionsFactory>();
        services.TryAddSingleton<TelegramBotClientOptions>(provider =>
            provider.GetRequiredService<TelegramBotClientOptionsFactory>().Create()
        );
        return services.AddConfiguration<ReceiverOptions>(configuration);
    }

    private static IServiceCollection TryAddTelegramBotListener(this IServiceCollection services)
    {
        services.AddHttpClient<TelegramBotListener>();
        services.TryAddSingleton<TelegramUpdateHandler>();
        services.TryAddSingleton<ITelegramBotListener, TelegramBotListener>();
        return services;
    }

    private static IServiceCollection TryAddTelegramBotClient(this IServiceCollection services)
    {
        services.AddHttpClient<TelegramBotClient>();
        services.TryAddSingleton<ITelegramBotClient, TelegramBotClient>();
        return services;
    }
}
