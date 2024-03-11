using DessertsMakery.Telegram.Infrastructure;

namespace DessertsMakery.Telegram.Worker;

public class Worker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Worker(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var listener = scope.ServiceProvider.GetRequiredService<ITelegramBotListener>();
        await listener.ReceiveAsync(stoppingToken);
    }
}
