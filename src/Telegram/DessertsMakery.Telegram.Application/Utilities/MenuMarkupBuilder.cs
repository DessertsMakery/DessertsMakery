using DessertsMakery.Telegram.Application.Menu;
using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities;

internal sealed class MenuMarkupBuilder : IMenuMarkupBuilder
{
    private readonly IMenuRoot _menuRoot;

    public MenuMarkupBuilder(IMenuRoot menuRoot)
    {
        _menuRoot = menuRoot;
    }

    public IReplyMarkup Build(IMenuSection section)
    {
        var buttons = GetButtons(section);
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
