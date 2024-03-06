namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages;

internal sealed class StartNotificationHandler : TextCommandTelegramNotificationHandler
{
    protected override string CommandName => "start";

    protected override Task HandleAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
