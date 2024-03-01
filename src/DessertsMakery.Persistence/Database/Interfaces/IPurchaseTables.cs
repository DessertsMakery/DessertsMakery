using DessertsMakery.Persistence.Models.Purchases;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IPurchaseTables
{
    DbSet<Purchase> Purchases { get; set; }
    DbSet<PurchaseItem> PurchaseItems { get; set; }
}
