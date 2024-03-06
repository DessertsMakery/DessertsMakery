namespace DessertsMakery.Telegram.Application.Notifications.Handlers;

internal sealed class TelegramHandlingContext<T>
{
    public TelegramNotification<T> Notification { get; set; }

    public TelegramHandlingContext(TelegramNotification<T> notification)
    {
        Notification = notification;
    }
}
