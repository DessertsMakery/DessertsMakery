namespace DessertsMakery.Persistence.Models.Orders;

public sealed class CustomPrice : Entity
{
    public decimal Value { get; set; }
    public string Reason { get; set; } = null!;

    public OrderItemDetails OrderItemDetails { get; set; } = null!;
}
