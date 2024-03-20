namespace DessertsMakery.Telegram.Application.Utilities.Localization;

internal sealed class EmptyTelegramMessageLocalizer : ITelegramMessageLocalizer
{
    public string Localize(LocalizationPart part, string key) => key;
}
