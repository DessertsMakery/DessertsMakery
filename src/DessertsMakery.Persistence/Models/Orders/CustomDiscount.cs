namespace DessertsMakery.Persistence.Models.Orders;

public sealed class CustomDiscount : Entity
{
    public decimal Value { get; set; }
    public string Reason { get; set; } = null!;

    public long OrderItemDetailsId { get; set; }
    public OrderItemDetails OrderItemDetails { get; set; } = null!;
}
