﻿using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Telegram.Application.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class TelegramUpdateHandler : IUpdateHandler
{
    private static readonly Type OpenGenericNotification = typeof(TelegramNotification<>);

    private readonly ITelegramAuthenticator _telegramAuthenticator;
    private readonly IUpdatePayloadMapper _updatePayloadMapper;
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TelegramUpdateHandler> _logger;

    public TelegramUpdateHandler(
        ITelegramAuthenticator telegramAuthenticator,
        IUpdatePayloadMapper updatePayloadMapper,
        IMediator mediator,
        IUnitOfWork unitOfWork,
        ILogger<TelegramUpdateHandler> logger
    )
    {
        _telegramAuthenticator = telegramAuthenticator;
        _updatePayloadMapper = updatePayloadMapper;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken
    )
    {
        _logger.LogInformation("{Id}, {Type}, {Message}", update.Id, update.Type, update.Message!.Text);
        var payload = _updatePayloadMapper.Map(update);
        if (!await _telegramAuthenticator.IsAuthenticatedAsync(payload, cancellationToken))
        {
            return;
        }

        var notificationType = OpenGenericNotification.MakeGenericType(payload.GetType());
        var notification = Activator.CreateInstance(notificationType, botClient, update.Id, update.Type, payload)!;
        await _mediator.Publish(notification, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        _logger.LogError(exception, "Exception is happened during polling");
        return Task.CompletedTask;
    }
}
