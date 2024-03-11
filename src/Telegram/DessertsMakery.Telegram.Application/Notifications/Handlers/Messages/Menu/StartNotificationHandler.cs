using DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Core;
using DessertsMakery.Telegram.Application.Utilities;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Menu;

internal sealed class StartNotificationHandler : TextCommandTelegramNotificationHandler
{
    public const string StartCommand = nameof(StartCommand);

    private readonly IMenuMarkupBuilder _menuMarkupBuilder;
    protected override string CommandName => "start";

    public StartNotificationHandler(IMenuMarkupBuilder menuMarkupBuilder)
    {
        _menuMarkupBuilder = menuMarkupBuilder;
    }

    protected override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var markup = await _menuMarkupBuilder.BuildAsync(cancellationToken);
        await Client.SendTextMessageAsync(
            Chat,
            StartCommand,
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }
}
