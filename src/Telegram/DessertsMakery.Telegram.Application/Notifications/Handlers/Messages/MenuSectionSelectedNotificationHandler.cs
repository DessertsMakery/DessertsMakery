using CSharpFunctionalExtensions;
using DessertsMakery.Common;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Users;
using DessertsMakery.Telegram.Application.Utilities;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages;

internal sealed class MenuSectionSelectedNotificationHandler : MessageTelegramNotificationHandler
{
    private readonly IUserMenuState _userMenuState;
    private readonly IMenuMarkupBuilder _menuMarkupBuilder;

    private Breadcrumbs? _breadcrumbs;

    public MenuSectionSelectedNotificationHandler(IUserMenuState userMenuState, IMenuMarkupBuilder menuMarkupBuilder)
    {
        _userMenuState = userMenuState;
        _menuMarkupBuilder = menuMarkupBuilder;
    }

    protected override Task<bool> CanHandleAsync(CancellationToken cancellationToken)
    {
        var hasChild = _userMenuState
            .TryGet()
            .Tap(breadcrumbs => _breadcrumbs = breadcrumbs)
            .Bind(x => x.Current.TryFindChild(Message.Text!))
            .HasValue;
        return Task.FromResult(hasChild);
    }

    protected override Task HandleAsync(CancellationToken cancellationToken)
    {
        var sectionName = _breadcrumbs!.GoTo(Message.Text!).Current.Name;
        var markup = _menuMarkupBuilder.Build();
        return Client.SendTextMessageAsync(
            Chat,
            sectionName,
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }
}
