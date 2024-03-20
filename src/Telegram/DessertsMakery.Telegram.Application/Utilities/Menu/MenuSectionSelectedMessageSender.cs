using CSharpFunctionalExtensions;
using DessertsMakery.Telegram.Application.Menu;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Application.Utilities.Menu;

internal sealed class MenuSectionSelectedMessageSender : IMenuSectionSelectedMessageSender
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IEnumerable<IMenuSectionMessageCreator> _creators;

    public MenuSectionSelectedMessageSender(
        ITelegramBotClient telegramBotClient,
        IEnumerable<IMenuSectionMessageCreator> creators
    )
    {
        _telegramBotClient = telegramBotClient;
        _creators = creators;
    }

    public Task TrySendAsync(Breadcrumbs breadcrumbs, ChatId chatId, CancellationToken token = default)
    {
        return _creators
            .SingleOrDefault(creator => creator.CanBeUsed(breadcrumbs))
            .AsMaybe()
            .Map(x => x.Create())
            .Execute(SendMessageAsync);

        Task<Message> SendMessageAsync(TelegramMessage message)
        {
            var (text, replyMarkup) = message;
            return _telegramBotClient.SendTextMessageAsync(
                chatId,
                text,
                replyMarkup: replyMarkup,
                cancellationToken: token
            );
        }
    }
}
