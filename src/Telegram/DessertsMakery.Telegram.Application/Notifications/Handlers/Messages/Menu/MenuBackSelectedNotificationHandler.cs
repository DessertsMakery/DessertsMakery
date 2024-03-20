using CSharpFunctionalExtensions;
using DessertsMakery.Common;
using DessertsMakery.Persistence.Repositories.Telegram;
using DessertsMakery.Telegram.Application.Menu;
using DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Core;
using DessertsMakery.Telegram.Application.Utilities;
using DessertsMakery.Telegram.Application.Utilities.Menu;
using Telegram.Bot;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers.Messages.Menu;

internal sealed class MenuBackSelectedNotificationHandler : MessageTelegramNotificationHandler
{
    private readonly IReadWriteTelegramRepository _telegramRepository;
    private readonly ITelegramUserAccessor _telegramUserAccessor;
    private readonly IMenuRoot _menuRoot;
    private readonly IMenuMarkupBuilder _menuMarkupBuilder;
    private readonly IMenuSectionSelectedMessageSender _menuSectionSelectedMessageSender;

    private string? _username;
    private Breadcrumbs? _breadcrumbs;

    public MenuBackSelectedNotificationHandler(
        IReadWriteTelegramRepository telegramRepository,
        ITelegramUserAccessor telegramUserAccessor,
        IMenuRoot menuRoot,
        IMenuMarkupBuilder menuMarkupBuilder,
        IMenuSectionSelectedMessageSender menuSectionSelectedMessageSender
    )
    {
        _telegramRepository = telegramRepository;
        _telegramUserAccessor = telegramUserAccessor;
        _menuRoot = menuRoot;
        _menuMarkupBuilder = menuMarkupBuilder;
        _menuSectionSelectedMessageSender = menuSectionSelectedMessageSender;
    }

    protected override async Task<bool> CanHandleAsync(CancellationToken cancellationToken)
    {
        if (!MenuSectionNames.Common.Back.Equals(Message.Text, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        _username = _telegramUserAccessor.TelegramUser.Map(x => x.Username).GetValueOrThrow("Cannot get username")!;
        var state = await _telegramRepository.GetMenuStateAsync(_username, cancellationToken);
        return Breadcrumbs
            .TryFrom(_menuRoot, state)
            .Tap(breadcrumbs => _breadcrumbs = breadcrumbs)
            .Map(breadcrumbs => breadcrumbs.Current.Parent is not null)
            .GetValueOrDefault();
    }

    protected override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var breadcrumbs = _breadcrumbs!.Back();
        await _telegramRepository.CreateOrUpdateMenuStateAsync(_username!, breadcrumbs.ToString(), cancellationToken);

        var section = breadcrumbs.Current;
        var markup = _menuMarkupBuilder.Build(section);
        await Client.SendTextMessageAsync(
            Chat,
            section.Name,
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
        await _menuSectionSelectedMessageSender.TrySendAsync(breadcrumbs, Chat, cancellationToken);
    }
}
