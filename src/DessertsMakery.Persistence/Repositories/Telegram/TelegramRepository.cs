using DessertsMakery.Persistence.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Repositories.Telegram;

internal sealed class TelegramRepository : IReadWriteTelegramRepository, IRepository
{
    private readonly ITelegramTables _telegramTables;

    public TelegramRepository(ITelegramTables telegramTables)
    {
        _telegramTables = telegramTables;
    }

    public Task<bool> ModeratorExistsAsync(string username, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(username);
        return _telegramTables.TelegramModerators.AnyAsync(
            moderator => username.Equals(moderator.Username, StringComparison.OrdinalIgnoreCase),
            cancellationToken: token
        );
    }

    public async Task<string?> GetMenuStateAsync(string username, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(username);

        var entity = await _telegramTables
            .TelegramModeratorMenuStates.Include(x => x.TelegramModerator)
            .FirstAsync(
                x => username.Equals(x.TelegramModerator.Username, StringComparison.OrdinalIgnoreCase),
                cancellationToken: token
            );

        return entity.MenuState!;
    }

    public async Task UpdateMenuStateAsync(string username, string state, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(state);

        var entity = await _telegramTables
            .TelegramModeratorMenuStates.Include(x => x.TelegramModerator)
            .FirstAsync(
                x => username.Equals(x.TelegramModerator.Username, StringComparison.OrdinalIgnoreCase),
                cancellationToken: token
            );

        entity.MenuState = state;
        _telegramTables.TelegramModeratorMenuStates.Update(entity);
    }
}
