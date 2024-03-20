using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace DessertsMakery.Common.Wrappers;

public interface IJsonSerializer
{
    string Serialize<T>(T value, JsonSerializerOptions? options = null);
    T? Deserialize<T>([StringSyntax("Json")] string json, JsonSerializerOptions? options = null);
}
