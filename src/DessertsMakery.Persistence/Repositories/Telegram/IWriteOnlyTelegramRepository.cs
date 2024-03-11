namespace DessertsMakery.Persistence.Repositories.Telegram;

public interface IWriteOnlyTelegramRepository
{
    Task UpdateMenuStateAsync(string username, string state, CancellationToken token);
}
