using CSharpFunctionalExtensions;
using DessertsMakery.Common;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Core;
using DessertsMakery.Telegram.Application.Users;
using DessertsMakery.Telegram.Application.Utilities;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Menu;

internal sealed class MenuSectionSelectedNotificationHandler : MessageTelegramNotificationHandler
{
    private readonly ITelegramModeratorMenuState _telegramModeratorMenuState;
    private readonly IMenuMarkupBuilder _menuMarkupBuilder;

    public MenuSectionSelectedNotificationHandler(
        ITelegramModeratorMenuState telegramModeratorMenuState,
        IMenuMarkupBuilder menuMarkupBuilder
    )
    {
        _telegramModeratorMenuState = telegramModeratorMenuState;
        _menuMarkupBuilder = menuMarkupBuilder;
    }

    protected override async Task<bool> CanHandleAsync(CancellationToken cancellationToken)
    {
        var child = await _telegramModeratorMenuState
            .TryGetAsync(cancellationToken)
            .Bind(x => x.Current.TryFindChild(Message.Text!));

        return child.HasValue;
    }

    protected override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var breadcrumbs = await _telegramModeratorMenuState
            .TryUpdateAsync(breadcrumbs => breadcrumbs.GoTo(Message.Text!), cancellationToken)
            .GetValueOrThrow($"Cannot find a breadcrumbs for `{From.Username}`");
        var markup = await _menuMarkupBuilder.BuildAsync(cancellationToken);
        await Client.SendTextMessageAsync(
            Chat,
            breadcrumbs.Current.Name,
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }
}
