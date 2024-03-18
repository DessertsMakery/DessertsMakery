using DessertsMakery.Telegram.Application.Menu;
using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities;

internal interface IMenuMarkupBuilder
{
    IReplyMarkup Build(IMenuSection section);
}
