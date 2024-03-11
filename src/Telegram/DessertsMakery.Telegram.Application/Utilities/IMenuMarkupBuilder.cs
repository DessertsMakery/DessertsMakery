using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities;

internal interface IMenuMarkupBuilder
{
    Task<IReplyMarkup> BuildAsync(CancellationToken token);
}
