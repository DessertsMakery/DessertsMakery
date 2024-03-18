namespace DessertsMakery.Persistence.Repositories.Telegram;

public interface IReadOnlyTelegramRepository
{
    Task<bool> ModeratorExistsAsync(string username, CancellationToken token);
    Task<string?> GetMenuStateAsync(string username, CancellationToken token);
}
