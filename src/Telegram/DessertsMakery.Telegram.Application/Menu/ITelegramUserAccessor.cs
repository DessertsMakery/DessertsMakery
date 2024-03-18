using CSharpFunctionalExtensions;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Menu;

public interface ITelegramUserAccessor
{
    Maybe<User> TelegramUser { get; }
}
