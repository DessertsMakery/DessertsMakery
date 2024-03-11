using CSharpFunctionalExtensions;
using DessertsMakery.Common;
using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Persistence.Repositories.Telegram;
using DessertsMakery.Telegram.Application.Menu;

namespace DessertsMakery.Telegram.Application.Users;

internal sealed class TelegramModeratorMenuState : ITelegramModeratorMenuState
{
    private readonly ITelegramUserAccessor _telegramUserAccessor;
    private readonly IReadWriteTelegramRepository _telegramRepository;
    private readonly IMenuRoot _menuRoot;
    private readonly IUnitOfWork _unitOfWork;

    public TelegramModeratorMenuState(
        ITelegramUserAccessor telegramUserAccessor,
        IReadWriteTelegramRepository telegramRepository,
        IMenuRoot menuRoot,
        IUnitOfWork unitOfWork
    )
    {
        _telegramUserAccessor = telegramUserAccessor;
        _telegramRepository = telegramRepository;
        _menuRoot = menuRoot;
        _unitOfWork = unitOfWork;
    }

    public Task<Maybe<Breadcrumbs>> TryGetAsync(CancellationToken token = default) =>
        TryGetUserBreadcrumbsAsync(token).Bind(x => x.Breadcrumbs);

    public Task<Maybe<Breadcrumbs>> TryGetOrSetAsync(Func<Breadcrumbs> factory, CancellationToken token = default)
    {
        return TryGetUserBreadcrumbsAsync(token).Bind(x => x.Breadcrumbs.Or(() => CreateNewFor(x.Username)));

        async Task<Breadcrumbs> CreateNewFor(string username)
        {
            var breadcrumbs = factory();
            await _telegramRepository.CreateOrUpdateMenuStateAsync(username, breadcrumbs.ToString(), token);
            return breadcrumbs;
        }
    }

    public Task<Maybe<Breadcrumbs>> TryUpdateAsync(Action<Breadcrumbs> configure, CancellationToken token = default)
    {
        return TryGetUserBreadcrumbsAsync(token)
            .Bind(x => x.Breadcrumbs)
            .Tap(configure)
            .Tap(_ => _unitOfWork.SaveChangesAsync(token));
    }

    private Task<Maybe<UserBreadcrumbs>> TryGetUserBreadcrumbsAsync(CancellationToken token) =>
        _telegramUserAccessor
            .TelegramUser.Where(x => !string.IsNullOrWhiteSpace(x.Username))
            .Map(x => x.Username!)
            .Map(async username =>
            {
                var state = await _telegramRepository.GetMenuStateAsync(username, token);
                var breadcrumbs = Breadcrumbs.TryFrom(_menuRoot, state);
                return new UserBreadcrumbs(username, breadcrumbs);
            });

    private sealed record UserBreadcrumbs(string Username, Maybe<Breadcrumbs> Breadcrumbs);
}
