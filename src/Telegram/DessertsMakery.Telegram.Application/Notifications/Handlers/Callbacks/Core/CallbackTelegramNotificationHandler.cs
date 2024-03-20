using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Callbacks.Core;

internal abstract class CallbackTelegramNotificationHandler : BaseTelegramNotificationHandler<CallbackQuery>
{
    protected CallbackQuery CallbackQuery => Payload;
    protected Message? SourceMessage => CallbackQuery.Message;
    protected User From => CallbackQuery.From;
}
