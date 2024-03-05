namespace DessertsMakery.Telegram.Infrastructure;

public interface ITelegramBotListener
{
    Task ReceiveAsync(CancellationToken cancellationToken = default);
}
