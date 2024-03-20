using CSharpFunctionalExtensions;
using DessertsMakery.Persistence.Repositories.Telegram;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Core;
using DessertsMakery.Telegram.Application.Utilities.Localization;
using DessertsMakery.Telegram.Application.Utilities.Menu;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Menu;

internal sealed class StartNotificationHandler : TextCommandTelegramNotificationHandler
{
    public const string StartCommand = nameof(StartCommand);

    private readonly IReadWriteTelegramRepository _telegramRepository;
    private readonly ITelegramUserAccessor _telegramUserAccessor;
    private readonly IMenuRoot _menuRoot;
    private readonly IMenuMarkupBuilder _menuMarkupBuilder;
    private readonly ITelegramMessageLocalizer _telegramMessageLocalizer;

    protected override string CommandName => "start";

    public StartNotificationHandler(
        IReadWriteTelegramRepository telegramRepository,
        ITelegramUserAccessor telegramUserAccessor,
        IMenuRoot menuRoot,
        IMenuMarkupBuilder menuMarkupBuilder,
        ITelegramMessageLocalizer telegramMessageLocalizer
    )
    {
        _telegramRepository = telegramRepository;
        _telegramUserAccessor = telegramUserAccessor;
        _menuRoot = menuRoot;
        _menuMarkupBuilder = menuMarkupBuilder;
        _telegramMessageLocalizer = telegramMessageLocalizer;
    }

    protected override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var username = _telegramUserAccessor.TelegramUser.Map(x => x.Username).GetValueOrThrow("Cannot get username")!;
        await _telegramRepository.CreateOrUpdateMenuStateAsync(username, _menuRoot.ToString()!, cancellationToken);
        var markup = _menuMarkupBuilder.Build(_menuRoot);
        var text = _telegramMessageLocalizer.Localize(LocalizationPart.Commands, StartCommand);
        await Client.SendTextMessageAsync(Chat, text, replyMarkup: markup, cancellationToken: cancellationToken);
    }
}
