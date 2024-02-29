namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailsImage : Entity
{
    public byte[] Image { get; set; } = null!;

    public long OrderItemDetailsId { get; set; }
    public OrderItemDetails OrderItemDetails { get; set; } = null!;
}
