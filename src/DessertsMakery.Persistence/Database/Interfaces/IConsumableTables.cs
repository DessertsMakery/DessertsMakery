using DessertsMakery.Persistence.Models.Consumables;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IConsumableTables : ITables
{
    DbSet<Consumable> Consumables { get; }
    DbSet<ConsumablePackaging> ConsumablePackagings { get; }
    DbSet<ConsumablePackagingImage> ConsumablePackagingImages { get; }
    DbSet<ConsumablePackagingPrice> ConsumablePackagingPrices { get; }
}
