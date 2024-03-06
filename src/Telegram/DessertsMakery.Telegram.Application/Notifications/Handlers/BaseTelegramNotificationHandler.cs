using Telegram.Bot.Types.Enums;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers;

internal abstract class BaseTelegramNotificationHandler<T> : ITelegramNotificationHandler<T>
{
    protected TelegramHandlingContext<T> Context { get; private set; } = null!;
    protected long UpdateId => Context.Notification.UpdateId;
    protected UpdateType UpdateType => Context.Notification.UpdateType;
    protected T Payload => Context.Notification.Payload;

    public async Task Handle(TelegramNotification<T> notification, CancellationToken cancellationToken)
    {
        Context = new TelegramHandlingContext<T>(notification);
        if (await CanHandleAsync(cancellationToken))
        {
            await HandleAsync(cancellationToken);
        }
    }

    protected abstract Task<bool> CanHandleAsync(CancellationToken cancellationToken);
    protected abstract Task HandleAsync(CancellationToken cancellationToken);
}
