namespace DessertsMakery.Persistence.Models.Telegram;

public sealed class TelegramModerator : Entity
{
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;

    public long? TelegramModeratorStateId { get; set; }
    public TelegramModeratorState? TelegramModeratorState { get; set; }
}
