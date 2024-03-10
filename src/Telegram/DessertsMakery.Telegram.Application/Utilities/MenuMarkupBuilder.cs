using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Users;
using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities;

internal sealed class MenuMarkupBuilder : IMenuMarkupBuilder
{
    private readonly IUserMenuState _userMenuState;
    private readonly IMenuRoot _menuRoot;

    public MenuMarkupBuilder(IUserMenuState userMenuState, IMenuRoot menuRoot)
    {
        _userMenuState = userMenuState;
        _menuRoot = menuRoot;
    }

    public IReplyMarkup Build()
    {
        var breadcrumbs = _userMenuState
            .TryGetOrSet(() => Breadcrumbs.Empty(_menuRoot))
            .GetValueOrThrow("Cannot build menu when no breadcrumbs");

        var buttons = GetButtons(breadcrumbs.Current);
        return new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true, IsPersistent = true };
    }

    private static IEnumerable<KeyboardButton> GetButtons(IMenuSection current)
    {
        var buttons = current.Children.Select(child => new KeyboardButton(child.Name));
        if (current.Parent is not null)
        {
            buttons = buttons.Append(MenuSectionNames.Common.Back);
        }

        return buttons;
    }
}
