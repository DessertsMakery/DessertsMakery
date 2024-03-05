using DessertsMakery.Telegram.Infrastructure;

namespace DessertsMakery.Telegram.Worker;

public class Worker : BackgroundService
{
    private readonly ITelegramBotListener _telegramBotListener;
    private readonly ILogger<Worker> _logger;

    public Worker(ITelegramBotListener telegramBotListener, ILogger<Worker> logger)
    {
        _telegramBotListener = telegramBotListener;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _telegramBotListener.ReceiveAsync(stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
