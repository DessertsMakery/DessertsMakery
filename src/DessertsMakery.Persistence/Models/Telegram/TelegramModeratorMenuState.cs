namespace DessertsMakery.Persistence.Models.Telegram;

public sealed class TelegramModeratorMenuState : Entity
{
    public string? MenuState { get; set; }

    public TelegramModerator TelegramModerator { get; set; } = null!;
}
