using DessertsMakery.Telegram.Application.Menu;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Utilities.Menu;

internal interface IMenuSectionSelectedMessageSender
{
    Task TrySendAsync(Breadcrumbs breadcrumbs, ChatId chatId, CancellationToken token = default);
}
