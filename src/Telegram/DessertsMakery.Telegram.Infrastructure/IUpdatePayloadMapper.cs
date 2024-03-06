using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Infrastructure;

internal interface IUpdatePayloadMapper
{
    object Map(Update update);
}
