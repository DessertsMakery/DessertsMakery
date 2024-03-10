using CSharpFunctionalExtensions;
using DessertsMakery.Telegram.Application.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramAuthenticator : ITelegramAuthenticator, IUserAccessor
{
    private readonly IOptionsSnapshot<UserConfiguration> _options;
    private readonly ILogger<TelegramAuthenticator> _logger;

    public Maybe<User> User { get; private set; }

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

        var isAuthenticated = _options.Value.AllowedUsernames?.Contains(username) == true;
        if (!isAuthenticated)
        {
            _logger.LogWarning("Username `{Username}` is not whitelisted", username);
        }

        return isAuthenticated;
    }

    private string? TryGetUsername(object payload)
    {
        var user = payload switch
        {
            Message message => message.From!,
            InlineQuery inlineQuery => inlineQuery.From,
            ChosenInlineResult chosenInlineResult => chosenInlineResult.From,
            CallbackQuery callbackQuery => callbackQuery.From,
            ShippingQuery shippingQuery => shippingQuery.From,
            PreCheckoutQuery preCheckoutQuery => preCheckoutQuery.From,
            Poll => null,
            PollAnswer pollAnswer => pollAnswer.User,
            ChatMemberUpdated chatMemberUpdated => chatMemberUpdated.From,
            ChatJoinRequest chatJoinRequest => chatJoinRequest.From,
            _ => throw new ArgumentOutOfRangeException(nameof(payload), payload, null)
        };
        User = user!;
        return user?.Username;
    }
}
