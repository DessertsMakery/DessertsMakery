using DessertsMakery.Common.Wrappers;
using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Persistence.Database.Seeding;
using DessertsMakery.Persistence.Models.Telegram;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Repositories.Telegram;

internal sealed class ReadWriteTelegramRepository : IReadWriteTelegramRepository, IRepository
{
    private readonly ITelegramTables _telegramTables;
    private readonly IEntitySeeder _entitySeeder;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ReadWriteTelegramRepository(
        ITelegramTables telegramTables,
        IEntitySeeder entitySeeder,
        IDateTimeProvider dateTimeProvider
    )
    {
        _telegramTables = telegramTables;
        _entitySeeder = entitySeeder;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<bool> ModeratorExistsAsync(string username, CancellationToken token)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        return _telegramTables.TelegramModerators.AnyAsync(
            moderator => username == moderator.Username,
            cancellationToken: token
        );
    }

    public async Task<string?> GetMenuStateAsync(string username, CancellationToken token)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);

        var entity = await _telegramTables
            .TelegramModerators.Include(x => x.TelegramModeratorMenuState)
            .FirstAsync(x => username == x.Username, cancellationToken: token);

        return entity.TelegramModeratorMenuState?.MenuState;
    }

    public async Task CreateOrUpdateMenuStateAsync(string username, string state, CancellationToken token)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);

        var moderator = await _telegramTables
            .TelegramModerators.Include(x => x.TelegramModeratorMenuState)
            .FirstAsync(x => username == x.Username, cancellationToken: token);

        if (moderator.TelegramModeratorMenuState is null)
        {
            await AddTelegramModeratorMenuState(moderator, state, token);
            return;
        }

        UpdateTelegramModeratorMenuState(state, moderator);
    }

    #region Helpers

    private async Task AddTelegramModeratorMenuState(TelegramModerator moderator, string state, CancellationToken token)
    {
        var telegramModeratorMenuState = new TelegramModeratorMenuState
        {
            TelegramModerator = moderator,
            MenuState = state
        };
        _entitySeeder.Seed(telegramModeratorMenuState);
        await _telegramTables.TelegramModeratorMenuStates.AddAsync(telegramModeratorMenuState, token);
    }

    private void UpdateTelegramModeratorMenuState(string state, TelegramModerator moderator)
    {
        moderator.TelegramModeratorMenuState!.MenuState = state;
        moderator.TelegramModeratorMenuState.ModifiedAt = _dateTimeProvider.GetUtcNow();
        _telegramTables.TelegramModeratorMenuStates.Update(moderator.TelegramModeratorMenuState);
    }

    #endregion
}
