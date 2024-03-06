using DessertsMakery.Telegram.Application.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramAuthenticator : ITelegramAuthenticator
{
    private readonly IOptionsSnapshot<UserConfiguration> _options;
    private readonly ILogger<TelegramAuthenticator> _logger;

    public TelegramAuthenticator(IOptionsSnapshot<UserConfiguration> options, ILogger<TelegramAuthenticator> logger)
    {
        _options = options;
        _logger = logger;
    }

    public bool IsAuthenticated(object payload)
    {
        var username = TryGetUsername(payload);
        if (string.IsNullOrWhiteSpace(username))
        {
            _logger.LogWarning("Couldn't extract user from payload: {@Payload}", payload);
            return false;
        }

        var isAuthenticated = _options.Value.AllowedUserNames?.Contains(username) == true;
        if (!isAuthenticated)
        {
            _logger.LogWarning("Username `{Username}` is not whitelisted", username);
        }

        return isAuthenticated;
    }

    private string? TryGetUsername(object payload)
    {
        return payload switch
        {
            Message message => message.From!.Username,
            InlineQuery inlineQuery => inlineQuery.From.Username,
            ChosenInlineResult chosenInlineResult => chosenInlineResult.From.Username,
            CallbackQuery callbackQuery => callbackQuery.From.Username,
            ShippingQuery shippingQuery => shippingQuery.From.Username,
            PreCheckoutQuery preCheckoutQuery => preCheckoutQuery.From.Username,
            Poll => null,
            PollAnswer pollAnswer => pollAnswer.User.Username,
            ChatMemberUpdated chatMemberUpdated => chatMemberUpdated.From.Username,
            ChatJoinRequest chatJoinRequest => chatJoinRequest.From.Username,
            _ => throw new ArgumentOutOfRangeException(nameof(payload), payload, null)
        };
    }
}
