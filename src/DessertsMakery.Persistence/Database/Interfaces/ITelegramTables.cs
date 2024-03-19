using DessertsMakery.Persistence.Models.Telegram;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface ITelegramTables : ITables
{
    DbSet<TelegramModerator> TelegramModerators { get; }
    DbSet<TelegramModeratorState> TelegramModeratorMenuStates { get; }
}
