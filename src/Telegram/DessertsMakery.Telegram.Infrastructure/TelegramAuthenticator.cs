using CSharpFunctionalExtensions;
using DessertsMakery.Persistence.Repositories.Telegram;
using DessertsMakery.Telegram.Application.Menu;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramAuthenticator : ITelegramAuthenticator, ITelegramUserAccessor
{
    private readonly IReadOnlyTelegramRepository _telegramRepository;
    private readonly ILogger<TelegramAuthenticator> _logger;

    public Maybe<User> TelegramUser { get; private set; }

    public TelegramAuthenticator(IReadOnlyTelegramRepository telegramRepository, ILogger<TelegramAuthenticator> logger)
    {
        _telegramRepository = telegramRepository;
        _logger = logger;
    }

    public async Task<bool> IsAuthenticatedAsync(object payload, CancellationToken token)
    {
        var username = TryGetUsername(payload);
        if (string.IsNullOrWhiteSpace(username))
        {
            _logger.LogWarning("Couldn't extract user from payload: {@Payload}", payload);
            return false;
        }

        var isAuthenticated = await _telegramRepository.ModeratorExistsAsync(username, token);
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
        TelegramUser = user!;
        return user?.Username;
    }
}
