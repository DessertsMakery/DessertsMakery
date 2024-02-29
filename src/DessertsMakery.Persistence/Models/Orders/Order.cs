using DessertsMakery.Persistence.Models.Customers;

namespace DessertsMakery.Persistence.Models.Orders;

public sealed class Order : Entity
{
    public DateTime ReceivingDate { get; set; }

    public long CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public string? Comment { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
