using MediatR;
using Telegram.Bot.Types.Enums;

namespace DessertsMakery.Telegram.Application.Notifications;

public record TelegramNotification<T>(long UpdateId, UpdateType UpdateType, T Payload) : INotification;
