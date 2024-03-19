namespace DessertsMakery.Persistence.Models.Telegram;

public sealed class TelegramModeratorState : Entity
{
    public string? MenuState { get; set; }
    public string? OperationState { get; set; }

    public TelegramModerator TelegramModerator { get; set; } = null!;
}
