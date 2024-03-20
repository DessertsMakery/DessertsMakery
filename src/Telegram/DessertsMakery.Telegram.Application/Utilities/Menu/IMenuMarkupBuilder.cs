using DessertsMakery.Telegram.Application.Menu;
using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities.Menu;

internal interface IMenuMarkupBuilder
{
    IReplyMarkup Build(IMenuSection section);
}
