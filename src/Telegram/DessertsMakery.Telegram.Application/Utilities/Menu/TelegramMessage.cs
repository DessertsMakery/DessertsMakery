using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities.Menu;

internal record TelegramMessage(string Text, IReplyMarkup? Markup = null);
