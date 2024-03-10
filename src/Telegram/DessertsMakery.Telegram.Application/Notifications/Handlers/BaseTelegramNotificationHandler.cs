using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers;

internal abstract class BaseTelegramNotificationHandler<T> : ITelegramNotificationHandler<T>
{
    #region State

    protected TelegramHandlingContext<T> Context { get; private set; } = null!;
    protected TelegramNotification<T> Notification => Context.Notification;
    protected ITelegramBotClient Client => Notification.Client;
    protected long UpdateId => Notification.UpdateId;
    protected UpdateType UpdateType => Notification.UpdateType;
    protected T Payload => Notification.Payload;

    #endregion

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
