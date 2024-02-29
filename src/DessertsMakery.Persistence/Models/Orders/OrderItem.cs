using DessertsMakery.Persistence.Models.Cakes;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItem : Entity
{
    public int Quantity { get; set; }

    public long CakeTemplateId { get; set; }
    public CakeTemplate CakeTemplate { get; set; } = null!;

    public long OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public long OrderItemDetailsId { get; set; }
    public OrderItemDetails OrderItemDetails { get; set; } = null!;
}
