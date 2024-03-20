namespace DessertsMakery.Telegram.Application.Utilities.Callbacks;

internal interface ITelegramCallbackSerializer
{
    string Serialize<TValue>(TValue value);
    bool CanBeDeserialized<TValue>(string callbackData);
    TValue? Deserialize<TValue>(string callbackData);
}
