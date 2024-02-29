using DessertsMakery.Persistence.Models.Desserts;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItem : Entity
{
    public int Quantity { get; set; }

    public long DessertTemplateId { get; set; }
    public DessertTemplate DessertTemplate { get; set; } = null!;

    public long OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public long OrderItemDetailsId { get; set; }
    public OrderItemDetails OrderItemDetails { get; set; } = null!;
}
