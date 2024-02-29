namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetails : Entity
{
    public long OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; } = null!;

    public string? Comment { get; set; }

    public long? CustomPriceId { get; set; }
    public CustomPrice? CustomPrice { get; set; }

    public long? CustomDiscountId { get; set; }
    public CustomDiscount? CustomDiscount { get; set; }

    public ICollection<OrderItemDetailsImage> OrderItemDetailsImages { get; set; } = new List<OrderItemDetailsImage>();
}
