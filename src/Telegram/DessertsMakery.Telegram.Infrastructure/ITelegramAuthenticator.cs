namespace DessertsMakery.Telegram.Infrastructure;

internal interface ITelegramAuthenticator
{
    Task<bool> IsAuthenticatedAsync(object payload, CancellationToken token);
}
