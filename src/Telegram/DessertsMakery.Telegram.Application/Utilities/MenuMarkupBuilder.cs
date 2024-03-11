using CSharpFunctionalExtensions;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Users;
using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities;

internal sealed class MenuMarkupBuilder : IMenuMarkupBuilder
{
    private readonly ITelegramModeratorMenuState _telegramModeratorMenuState;
    private readonly IMenuRoot _menuRoot;

    public MenuMarkupBuilder(ITelegramModeratorMenuState telegramModeratorMenuState, IMenuRoot menuRoot)
    {
        _telegramModeratorMenuState = telegramModeratorMenuState;
        _menuRoot = menuRoot;
    }

    public async Task<IReplyMarkup> BuildAsync(CancellationToken token)
    {
        var breadcrumbs = await _telegramModeratorMenuState
            .TryGetOrSetAsync(() => Breadcrumbs.Empty(_menuRoot), token)
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
