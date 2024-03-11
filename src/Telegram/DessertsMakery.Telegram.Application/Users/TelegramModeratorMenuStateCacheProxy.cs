using System.Diagnostics.CodeAnalysis;
using CSharpFunctionalExtensions;
using DessertsMakery.Common;
using DessertsMakery.Telegram.Application.Menu;
using Microsoft.Extensions.Caching.Memory;

namespace DessertsMakery.Telegram.Application.Users;

internal sealed class TelegramModeratorMenuStateCacheProxy : ITelegramModeratorMenuState
{
    private readonly ITelegramModeratorMenuState _original;
    private readonly IMemoryCache _memoryCache;
    private readonly ITelegramUserAccessor _telegramUserAccessor;

    public TelegramModeratorMenuStateCacheProxy(
        ITelegramModeratorMenuState original,
        IMemoryCache memoryCache,
        ITelegramUserAccessor telegramUserAccessor
    )
    {
        _original = original;
        _memoryCache = memoryCache;
        _telegramUserAccessor = telegramUserAccessor;
    }

    public Task<Maybe<Breadcrumbs>> TryGetAsync(CancellationToken token = default)
    {
        return TryGetUserKey()
            .Bind(key => _memoryCache.Get<Breadcrumbs>(key).AsMaybe())
            .Or(() => _original.TryGetAsync(token));
    }

    public Task<Maybe<Breadcrumbs>> TryGetOrSetAsync(Func<Breadcrumbs> factory, CancellationToken token = default)
    {
        return TryGetUserKey().Bind(TryGetFromCache).Or(TryGetOrSetFromOriginal).Tap(SaveInCache);

        #region Local Functions

        Task<Maybe<Breadcrumbs>> TryGetOrSetFromOriginal() => _original.TryGetOrSetAsync(factory, token);

        void SaveInCache(Breadcrumbs breadcrumbs) =>
            TryGetUserKey()
                .Tap(key =>
                    _memoryCache.Set(
                        key,
                        breadcrumbs,
                        new MemoryCacheEntryOptions { Priority = CacheItemPriority.NeverRemove }
                    )
                );

        #endregion
    }

    public Task<Maybe<Breadcrumbs>> TryUpdateAsync(Action<Breadcrumbs> configure, CancellationToken token = default) =>
        TryGetUserKey().Bind(TryGetFromCache).Tap(configure).Bind(_ => _original.TryUpdateAsync(configure, token));

    private Maybe<UserKey> TryGetUserKey() =>
        _telegramUserAccessor
            .TelegramUser.Where(x => !string.IsNullOrWhiteSpace(x.Username))
            .Map(x => x.Username!)
            .Map(username => new UserKey(username));

    private Maybe<Breadcrumbs> TryGetFromCache(UserKey key) => _memoryCache.Get<Breadcrumbs>(key).AsMaybe();

    [SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Local")]
    private sealed record UserKey(string Username);
}
