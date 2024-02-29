using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class OrderItemDetailPackagingComponent : Entity
{
    public long OrderItemDetailsId { get; set; }
    public OrderItemDetails OrderItemDetails { get; set; } = null!;

    public long PackagingComponentId { get; set; }
    public PackagingComponent PackagingComponent { get; set; } = null!;
}
