namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetails : Entity
{
    public string? Comment { get; set; }

    public long? CustomPriceId { get; set; }
    public CustomPrice? CustomPrice { get; set; }

    public long? CustomDiscountId { get; set; }
    public CustomDiscount? CustomDiscount { get; set; }

    public OrderItem OrderItem { get; set; } = null!;
    public ICollection<OrderItemDetailPackagingComponent> PackagingComponents { get; set; } =
        new List<OrderItemDetailPackagingComponent>();
    public ICollection<OrderItemDetailsAddition> Additions { get; set; } = new List<OrderItemDetailsAddition>();
    public ICollection<OrderItemDetailsImage> OrderItemDetailsImages { get; set; } = new List<OrderItemDetailsImage>();
}
