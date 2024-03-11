namespace DessertsMakery.Persistence.Models.Telegram;

public sealed class TelegramModerator : Entity
{
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;

    public long TelegramModeratorMenuStateId { get; set; }
    public TelegramModeratorMenuState TelegramModeratorMenuState { get; set; } = null!;
}
