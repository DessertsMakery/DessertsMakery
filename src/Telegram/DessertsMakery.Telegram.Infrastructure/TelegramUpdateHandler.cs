using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramUpdateHandler : IUpdateHandler
{
    private readonly ILogger<TelegramUpdateHandler> _logger;

    public TelegramUpdateHandler(ILogger<TelegramUpdateHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{Id}, {Type}", update.Id, update.Type);
        return Task.CompletedTask;
    }

    public Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        _logger.LogError(exception, "Exception is happened during polling");
        return Task.CompletedTask;
    }
}
