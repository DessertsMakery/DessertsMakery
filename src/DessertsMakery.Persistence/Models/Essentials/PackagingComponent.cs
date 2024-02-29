using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Essentials;

public sealed class PackagingComponent : Component
{
    public ICollection<OrderItemDetailPackagingComponent> OrderItemDetailPackagingComponents { get; set; } =
        new List<OrderItemDetailPackagingComponent>();
}
