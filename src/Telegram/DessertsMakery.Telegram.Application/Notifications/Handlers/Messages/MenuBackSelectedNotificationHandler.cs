using CSharpFunctionalExtensions;
using DessertsMakery.Common;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Users;
using DessertsMakery.Telegram.Application.Utilities;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages;

internal sealed class MenuBackSelectedNotificationHandler : MessageTelegramNotificationHandler
{
    private readonly IUserMenuState _userMenuState;
    private readonly IMenuMarkupBuilder _menuMarkupBuilder;

    private Breadcrumbs? _breadcrumbs;

    public MenuBackSelectedNotificationHandler(IUserMenuState userMenuState, IMenuMarkupBuilder menuMarkupBuilder)
    {
        _userMenuState = userMenuState;
        _menuMarkupBuilder = menuMarkupBuilder;
    }

    protected override Task<bool> CanHandleAsync(CancellationToken cancellationToken)
    {
        if (!MenuSectionNames.Common.Back.Equals(Message.Text, StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(false);
        }

        var hasParent = _userMenuState
            .TryGet()
            .Tap(breadcrumbs => _breadcrumbs = breadcrumbs)
            .Map(x => x.Current.Parent!)
            .HasValue;
        return Task.FromResult(hasParent);
    }

    protected override Task HandleAsync(CancellationToken cancellationToken)
    {
        var sectionName = _breadcrumbs!.Back().Current.Name;
        var markup = _menuMarkupBuilder.Build();
        return Client.SendTextMessageAsync(
            Chat,
            sectionName,
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }
}
