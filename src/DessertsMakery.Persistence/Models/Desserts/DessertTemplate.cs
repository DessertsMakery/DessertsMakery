using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertTemplate : Entity
{
    public string Name { get; set; } = null!;

    public long DessertFamilyId { get; set; }
    public DessertFamily DessertFamily { get; set; } = null!;

    public long DessertWeightId { get; set; }
    public DessertWeight DessertWeight { get; set; } = null!;

    public ICollection<DessertTemplateRecipe> DessertTemplateRecipes { get; set; } = new List<DessertTemplateRecipe>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
