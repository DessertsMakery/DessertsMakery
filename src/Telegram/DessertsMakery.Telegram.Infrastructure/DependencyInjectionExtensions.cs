using DessertsMakery.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
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
        services.AddConfiguration<TelegramConfiguration>(configuration);
        services.TryAddScoped(TelegramBotClientOptionsFactory);
        services.TryAddTelegramBotListener();
        services.TryAddTelegramBotClient();
        return services;
    }

    private static TelegramBotClientOptions TelegramBotClientOptionsFactory(IServiceProvider provider)
    {
        var configuration = provider.GetRequiredService<IOptionsSnapshot<TelegramConfiguration>>().Value;
        return new TelegramBotClientOptions(configuration.Token);
    }

    private static void TryAddTelegramBotListener(this IServiceCollection services)
    {
        services.TryAddSingleton<ReceiverOptions>();
        services.AddHttpClient<TelegramBotListener>();
        services.TryAddSingleton<TelegramUpdateHandler>();
        services.TryAddSingleton<ITelegramBotListener, TelegramBotListener>();
    }

    private static void TryAddTelegramBotClient(this IServiceCollection services)
    {
        services.AddHttpClient<TelegramBotClient>();
        services.TryAddSingleton<ITelegramBotClient, TelegramBotClient>();
    }
}
