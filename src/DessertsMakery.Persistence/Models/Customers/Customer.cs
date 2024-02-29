using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Customers;

public sealed class Customer : Entity
{
    public string Username { get; set; } = null!;
    public string? Name { get; set; }
    public string? Comment { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
