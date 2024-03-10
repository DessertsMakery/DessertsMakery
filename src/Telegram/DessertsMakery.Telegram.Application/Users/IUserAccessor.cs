using CSharpFunctionalExtensions;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Users;

public interface IUserAccessor
{
    Maybe<User> User { get; }
}
