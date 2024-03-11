using CSharpFunctionalExtensions;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Users;

public interface ITelegramUserAccessor
{
    Maybe<User> TelegramUser { get; }
}
