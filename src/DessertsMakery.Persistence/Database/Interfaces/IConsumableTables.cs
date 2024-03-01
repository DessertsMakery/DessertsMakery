using DessertsMakery.Persistence.Models.Consumables;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IConsumableTables : ITables
{
    DbSet<Consumable> Consumables { get; set; }
    DbSet<ConsumablePackaging> ConsumablePackagings { get; set; }
    DbSet<ConsumablePackagingImage> ConsumablePackagingImages { get; set; }
    DbSet<ConsumablePackagingPrice> ConsumablePackagingPrices { get; set; }
}
