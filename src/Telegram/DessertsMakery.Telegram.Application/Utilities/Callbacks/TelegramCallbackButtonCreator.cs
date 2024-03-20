using Telegram.Bot.Types.ReplyMarkups;

namespace DessertsMakery.Telegram.Application.Utilities.Callbacks;

internal sealed class TelegramCallbackButtonCreator : ITelegramCallbackButtonCreator
{
    private const int MaxCallbackDataLength = 64;
    private readonly ITelegramCallbackSerializer _callbackSerializer;

    public TelegramCallbackButtonCreator(ITelegramCallbackSerializer callbackSerializer)
    {
        _callbackSerializer = callbackSerializer;
    }

    public IKeyboardButton Create<T>(string text, T payload)
    {
        var callbackData = _callbackSerializer.Serialize(payload);
        ThrowIfMaxLengthIsExceeded(callbackData);
        return InlineKeyboardButton.WithCallbackData(text, callbackData);
    }

    private static void ThrowIfMaxLengthIsExceeded(string callbackData)
    {
        if (callbackData.Length > MaxCallbackDataLength)
        {
            throw new InvalidOperationException(
                $"Cannot use callback data because of exceeding ({callbackData.Length}) max length: `{callbackData}`"
            );
        }
    }
}
