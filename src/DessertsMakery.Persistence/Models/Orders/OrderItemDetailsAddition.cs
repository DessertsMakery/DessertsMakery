using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailsAddition : Entity
{
    public long OrderItemDetailsId { get; set; }
    public OrderItemDetails OrderItemDetails { get; set; } = null!;

    public long AdditionId { get; set; }
    public Addition Addition { get; set; } = null!;
}
