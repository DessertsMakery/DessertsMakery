using CSharpFunctionalExtensions;
using DessertsMakery.Telegram.Application.Menu;
using Microsoft.Extensions.Caching.Memory;

namespace DessertsMakery.Telegram.Application.Users;

internal sealed class UserMenuState : IUserMenuState
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserAccessor _userAccessor;

    public UserMenuState(IMemoryCache memoryCache, IUserAccessor userAccessor)
    {
        _memoryCache = memoryCache;
        _userAccessor = userAccessor;
    }

    public Maybe<Breadcrumbs> TryGet() => TryGetUserKey().Bind(key => _memoryCache.Get<Breadcrumbs>(key).AsMaybe());

    public Maybe<Breadcrumbs> TryGetOrSet(Func<Breadcrumbs> factory)
    {
        return TryGetUserKey().Bind(key => _memoryCache.GetOrCreate(key, BreadcrumbsFactory).AsMaybe());

        Breadcrumbs BreadcrumbsFactory(ICacheEntry cache)
        {
            cache.Priority = CacheItemPriority.NeverRemove;
            return factory();
        }
    }

    private Maybe<UserKey> TryGetUserKey() =>
        _userAccessor
            .User.Where(x => !string.IsNullOrWhiteSpace(x.Username))
            .Map(x => x.Username!)
            .Map(username => new UserKey(username));

    private sealed record UserKey(string Username);
}
