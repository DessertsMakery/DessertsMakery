namespace DessertsMakery.Persistence.Repositories.Telegram;

public interface IWriteOnlyTelegramRepository
{
    Task CreateOrUpdateMenuStateAsync(string username, string state, CancellationToken token);
}
