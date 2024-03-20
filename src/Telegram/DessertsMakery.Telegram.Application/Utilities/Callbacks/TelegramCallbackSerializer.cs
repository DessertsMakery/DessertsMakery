using System.Reflection;
using System.Text.Json;
using DessertsMakery.Common.Wrappers;

namespace DessertsMakery.Telegram.Application.Utilities.Callbacks;

internal sealed class TelegramCallbackSerializer : ITelegramCallbackSerializer
{
    private const char Separator = '|';
    private static readonly JsonSerializerOptions Options =
        new() { WriteIndented = false, AllowTrailingCommas = false };
    private readonly IJsonSerializer _serializer;

    public TelegramCallbackSerializer(IJsonSerializer serializer)
    {
        _serializer = serializer;
    }

    public string Serialize<TValue>(TValue value)
    {
        var metadata = GetMetadataAttribute<TValue>();
        var serialized = _serializer.Serialize(value, Options);
        return $"{metadata.Shortname}{Separator}{serialized}";
    }

    public bool CanBeDeserialized<TValue>(string callbackData)
    {
        var metadata = GetMetadataAttribute<TValue>();
        var index = callbackData.IndexOf(Separator);
        var prefix = callbackData[..index];
        return prefix.Equals(metadata.Shortname, StringComparison.Ordinal);
    }

    public TValue? Deserialize<TValue>(string callbackData)
    {
        var metadata = GetMetadataAttribute<TValue>();
        var index = callbackData.IndexOf(Separator);
        var suffix = callbackData[index..];
        return _serializer.Deserialize<TValue>(suffix, Options);
    }

    private static CallbackMetadataAttribute GetMetadataAttribute<TValue>()
    {
        var valueType = typeof(TValue);
        var attributeType = typeof(CallbackMetadataAttribute);
        if (valueType.GetCustomAttribute(attributeType) is not CallbackMetadataAttribute metadata)
        {
            throw new InvalidOperationException(
                $"The type of `{valueType}` is not decorated with attribute `{attributeType}`"
            );
        }

        return metadata;
    }
}
