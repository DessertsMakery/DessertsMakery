using DessertsMakery.Persistence.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IOrderTables
{
    DbSet<CustomDiscount> CustomDiscounts { get; set; }
    DbSet<CustomPrice> CustomPrices { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderItem> OrderItems { get; set; }
    DbSet<OrderItemDetailPackagingComponent> OrderItemDetailPackagingComponents { get; set; }
    DbSet<OrderItemDetails> OrderItemDetails { get; set; }
    DbSet<OrderItemDetailsAddition> OrderItemDetailsAdditions { get; set; }
    DbSet<OrderItemDetailsImage> OrderItemDetailsImages { get; set; }
}
