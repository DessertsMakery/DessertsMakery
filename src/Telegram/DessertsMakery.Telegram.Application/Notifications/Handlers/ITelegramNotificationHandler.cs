using MediatR;

namespace DessertsMakery.Telegram.Application.Notifications.Handlers;

public interface ITelegramNotificationHandler<T> : INotificationHandler<TelegramNotification<T>> { }
