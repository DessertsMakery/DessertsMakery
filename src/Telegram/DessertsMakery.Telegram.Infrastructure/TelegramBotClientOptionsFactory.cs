using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramBotClientOptionsFactory
{
    private readonly IConfiguration _configuration;

    public TelegramBotClientOptionsFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TelegramBotClientOptions Create()
    {
        var section = _configuration.GetSection(nameof(TelegramBotClientOptions));
        var token = section[nameof(TelegramBotClientOptions.Token)];
        ArgumentException.ThrowIfNullOrWhiteSpace(token);
        return new TelegramBotClientOptions(token);
    }
}
