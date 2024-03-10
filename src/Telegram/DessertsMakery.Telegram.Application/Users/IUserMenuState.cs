using CSharpFunctionalExtensions;
using DessertsMakery.Telegram.Application.Menu;

namespace DessertsMakery.Telegram.Application.Users;

internal interface IUserMenuState
{
    Maybe<Breadcrumbs> TryGet();
    Maybe<Breadcrumbs> TryGetOrSet(Func<Breadcrumbs> factory);
}
