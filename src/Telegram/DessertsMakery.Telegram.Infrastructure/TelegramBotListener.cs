using Telegram.Bot;
using Telegram.Bot.Polling;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramBotListener : ITelegramBotListener
{
    private readonly TelegramUpdateHandler _telegramUpdateHandler;
    private readonly ReceiverOptions _receiverOptions;
    private readonly ITelegramBotClient _telegramBotClient;

    public TelegramBotListener(
        TelegramUpdateHandler telegramUpdateHandler,
        TelegramBotClientOptions telegramBotClientOptions,
        ReceiverOptions receiverOptions,
        HttpClient httpClient
    )
    {
        _telegramUpdateHandler = telegramUpdateHandler;
        _receiverOptions = receiverOptions;
        _telegramBotClient = new TelegramBotClient(telegramBotClientOptions, httpClient);
    }

    public Task ReceiveAsync(CancellationToken cancellationToken = default) =>
        _telegramBotClient.ReceiveAsync(_telegramUpdateHandler, _receiverOptions, cancellationToken);
}
