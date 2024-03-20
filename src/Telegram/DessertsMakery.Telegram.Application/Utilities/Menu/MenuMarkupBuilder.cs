using DessertsMakery.Telegram.Application.Menu;
using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities.Menu;

internal sealed class MenuMarkupBuilder : IMenuMarkupBuilder
{
    private const int RowSize = 2;

    public IReplyMarkup Build(IMenuSection section)
    {
        var buttons = GetButtons(section);
        return new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true, IsPersistent = true };
    }

    private static IEnumerable<KeyboardButton[]> GetButtons(IMenuSection current)
    {
        var buttons = current.Children.Select(child => new KeyboardButton(child.Name)).Chunk(RowSize);
        if (current.Parent is not null)
        {
            buttons = buttons.Append(new KeyboardButton[] { MenuSectionNames.Common.Back });
        }

        return buttons;
    }
}
