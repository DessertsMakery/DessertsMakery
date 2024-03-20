using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace DessertsMakery.Common.Wrappers;

internal sealed class JsonSerializerWrapper : IJsonSerializer, IWrapper
{
    public string Serialize<T>(T value, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(value, options);

    public T? Deserialize<T>([StringSyntax("Json")] string json, JsonSerializerOptions? options = null) =>
        JsonSerializer.Deserialize<T>(json, options);
}
