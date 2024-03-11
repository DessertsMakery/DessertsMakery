using CSharpFunctionalExtensions;
using DessertsMakery.Telegram.Application.Menu;

namespace DessertsMakery.Telegram.Application.Users;

internal interface ITelegramModeratorMenuState
{
    Task<Maybe<Breadcrumbs>> TryGetAsync(CancellationToken token = default);
    Task<Maybe<Breadcrumbs>> TryGetOrSetAsync(Func<Breadcrumbs> factory, CancellationToken token = default);
    Task<Maybe<Breadcrumbs>> TryUpdateAsync(Action<Breadcrumbs> configure, CancellationToken token = default);
}
