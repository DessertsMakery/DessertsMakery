using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DessertsMakery.Telegram.Infrastructure;

internal sealed class UpdatePayloadMapper : IUpdatePayloadMapper
{
    private static readonly Dictionary<UpdateType, Func<Update, object?>> Mappings =
        new()
        {
            { UpdateType.Message, update => update.Message },
            { UpdateType.InlineQuery, update => update.InlineQuery },
            { UpdateType.ChosenInlineResult, update => update.ChosenInlineResult },
            { UpdateType.CallbackQuery, update => update.CallbackQuery },
            { UpdateType.EditedMessage, update => update.EditedMessage },
            { UpdateType.ChannelPost, update => update.ChannelPost },
            { UpdateType.EditedChannelPost, update => update.EditedChannelPost },
            { UpdateType.ShippingQuery, update => update.ShippingQuery },
            { UpdateType.PreCheckoutQuery, update => update.PreCheckoutQuery },
            { UpdateType.Poll, update => update.Poll },
            { UpdateType.PollAnswer, update => update.PollAnswer },
            { UpdateType.MyChatMember, update => update.MyChatMember },
            { UpdateType.ChatMember, update => update.ChatMember },
            { UpdateType.ChatJoinRequest, update => update.ChatJoinRequest }
        };

    public object Map(Update update)
    {
        var exists = Mappings.TryGetValue(update.Type, out var strategy);
        if (exists)
        {
            return strategy!(update)!;
        }

        throw new InvalidOperationException($"Cannot find mapping strategy for update type: `{update.Type}`");
    }
}
