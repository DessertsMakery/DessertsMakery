using DessertsMakery.Telegram.Infrastructure;

namespace DessertsMakery.Telegram.Worker;

public class Worker : BackgroundService
{
    private readonly ITelegramBotListener _telegramBotListener;

    public Worker(ITelegramBotListener telegramBotListener)
    {
        _telegramBotListener = telegramBotListener;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return _telegramBotListener.ReceiveAsync(stoppingToken);
    }
}
