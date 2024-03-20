namespace DessertsMakery.Telegram.Application.Utilities.Localization;

public interface ITelegramMessageLocalizer
{
    string Localize(LocalizationPart part, string key);
}
