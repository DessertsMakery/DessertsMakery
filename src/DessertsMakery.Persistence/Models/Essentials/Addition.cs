using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class Addition : Component
{
    public ICollection<OrderItemDetailsAddition> OrderItemDetailsAdditions { get; set; } =
        new List<OrderItemDetailsAddition>();
}
