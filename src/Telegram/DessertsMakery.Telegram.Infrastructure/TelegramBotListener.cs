using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramBotListener : ITelegramBotListener
{
    private readonly TelegramUpdateHandler _telegramUpdateHandler;
    private readonly IOptionsMonitor<ReceiverOptions> _receiverOptionsMonitor;
    private readonly ITelegramBotClient _telegramBotClient;

    public TelegramBotListener(
        TelegramUpdateHandler telegramUpdateHandler,
        IOptionsMonitor<ReceiverOptions> receiverOptionsMonitorMonitor,
        TelegramBotClientOptions telegramBotClientOptions,
        HttpClient httpClient
    )
    {
        _telegramUpdateHandler = telegramUpdateHandler;
        _receiverOptionsMonitor = receiverOptionsMonitorMonitor;
        _telegramBotClient = new TelegramBotClient(telegramBotClientOptions, httpClient);
    }

    public Task ReceiveAsync(CancellationToken cancellationToken = default) =>
        _telegramBotClient.ReceiveAsync(
            _telegramUpdateHandler,
            _receiverOptionsMonitor.CurrentValue,
            cancellationToken
        );
}
