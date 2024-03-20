using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities.Callbacks;

internal interface ITelegramCallbackButtonCreator
{
    IKeyboardButton Create<T>(string text, T payload);
}
