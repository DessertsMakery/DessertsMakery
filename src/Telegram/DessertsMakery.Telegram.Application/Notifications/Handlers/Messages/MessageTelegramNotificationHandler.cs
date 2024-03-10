using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages;

internal abstract class MessageTelegramNotificationHandler : BaseTelegramNotificationHandler<Message>
{
    protected Message Message => Payload;
    protected Chat Chat => Message.Chat;
    protected User From => Message.From!;
}
