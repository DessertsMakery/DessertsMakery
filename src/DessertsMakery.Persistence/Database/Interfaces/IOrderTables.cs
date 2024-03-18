using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IOrderTables : ITables
{
    DbSet<CustomDiscount> CustomDiscounts { get; }
    DbSet<CustomPrice> CustomPrices { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<OrderItemDetailPackagingComponent> OrderItemDetailPackagingComponents { get; }
    DbSet<OrderItemDetails> OrderItemDetails { get; }
    DbSet<OrderItemDetailsAddition> OrderItemDetailsAdditions { get; }
    DbSet<OrderItemDetailsImage> OrderItemDetailsImages { get; }
}
