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
            .TelegramModerators.Include(x => x.TelegramModeratorState)
            .FirstAsync(x => username == x.Username, cancellationToken: token);

        return entity.TelegramModeratorState?.MenuState;
    }

    public async Task CreateOrUpdateMenuStateAsync(string username, string state, CancellationToken token)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);

        var moderator = await _telegramTables
            .TelegramModerators.Include(x => x.TelegramModeratorState)
            .FirstAsync(x => username == x.Username, cancellationToken: token);

        if (moderator.TelegramModeratorState is null)
        {
            await AddTelegramModeratorState(moderator, state, token);
            return;
        }

        UpdateTelegramModeratorState(state, moderator);
    }

    #region Helpers

    private async Task AddTelegramModeratorState(TelegramModerator moderator, string state, CancellationToken token)
    {
        var telegramModeratorState = new TelegramModeratorState { TelegramModerator = moderator, MenuState = state };
        _entitySeeder.Seed(telegramModeratorState);
        await _telegramTables.TelegramModeratorStates.AddAsync(telegramModeratorState, token);
    }

    private void UpdateTelegramModeratorState(string state, TelegramModerator moderator)
    {
        moderator.TelegramModeratorState!.MenuState = state;
        moderator.TelegramModeratorState.ModifiedAt = _dateTimeProvider.GetUtcNow();
        _telegramTables.TelegramModeratorStates.Update(moderator.TelegramModeratorState);
    }

    #endregion
}
