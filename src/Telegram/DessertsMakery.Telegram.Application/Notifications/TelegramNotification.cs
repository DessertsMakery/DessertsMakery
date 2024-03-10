using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace DessertsMakery.Telegram.Application.Notifications;

public record TelegramNotification<T>(ITelegramBotClient Client, long UpdateId, UpdateType UpdateType, T Payload)
    : INotification;
