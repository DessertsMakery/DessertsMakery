namespace DessertsMakery.Telegram.Infrastructure;

internal interface ITelegramAuthenticator
{
    bool IsAuthenticated(object payload);
}
