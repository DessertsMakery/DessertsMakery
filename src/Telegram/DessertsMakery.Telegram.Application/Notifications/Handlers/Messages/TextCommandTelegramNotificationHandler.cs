using Telegram.Bot.Types.Enums;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages;

internal abstract class TextCommandTelegramNotificationHandler : MessageTelegramNotificationHandler
{
    protected abstract string CommandName { get; }

    protected override Task<bool> CanHandleAsync(CancellationToken cancellationToken)
    {
        if (UpdateType != UpdateType.Message)
        {
            return Task.FromResult(false);
        }

        if (Payload.Entities?.FirstOrDefault(x => x.Type == MessageEntityType.BotCommand) is not { Offset: 0 } command)
        {
            return Task.FromResult(false);
        }

        var sameText = CommandName.Equals(Payload.Text![1..command.Length], StringComparison.OrdinalIgnoreCase);
        return Task.FromResult(sameText);
    }
}
