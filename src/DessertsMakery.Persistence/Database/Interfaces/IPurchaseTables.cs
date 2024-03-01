using DessertsMakery.Persistence.Models.Purchases;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IPurchaseTables : ITables
{
    DbSet<Purchase> Purchases { get; set; }
    DbSet<PurchaseItem> PurchaseItems { get; set; }
}
