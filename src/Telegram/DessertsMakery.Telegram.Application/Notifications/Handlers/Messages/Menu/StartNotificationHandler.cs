using CSharpFunctionalExtensions;
using DessertsMakery.Persistence.Repositories.Telegram;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Core;
using DessertsMakery.Telegram.Application.Utilities;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Menu;

internal sealed class StartNotificationHandler : TextCommandTelegramNotificationHandler
{
    public const string StartCommand = nameof(StartCommand);

    private readonly IReadWriteTelegramRepository _telegramRepository;
    private readonly ITelegramUserAccessor _telegramUserAccessor;
    private readonly IMenuRoot _menuRoot;
    private readonly IMenuMarkupBuilder _menuMarkupBuilder;

    protected override string CommandName => "start";

    public StartNotificationHandler(
        IReadWriteTelegramRepository telegramRepository,
        ITelegramUserAccessor telegramUserAccessor,
        IMenuRoot menuRoot,
        IMenuMarkupBuilder menuMarkupBuilder
    )
    {
        _telegramRepository = telegramRepository;
        _telegramUserAccessor = telegramUserAccessor;
        _menuRoot = menuRoot;
        _menuMarkupBuilder = menuMarkupBuilder;
    }

    protected override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var username = _telegramUserAccessor.TelegramUser.Map(x => x.Username).GetValueOrThrow("Cannot get username")!;
        await _telegramRepository.CreateOrUpdateMenuStateAsync(username, _menuRoot.ToString()!, cancellationToken);
        var markup = _menuMarkupBuilder.Build(_menuRoot);
        await Client.SendTextMessageAsync(
            Chat,
            StartCommand,
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }
}
