using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Desserts;

public sealed class DessertTemplate : Entity
{
    public string Name { get; set; } = null!;

    public long DessertFamilyWeightId { get; set; }
    public DessertFamilyWeight DessertFamilyWeight { get; set; } = null!;

    public ICollection<DessertTemplateRecipe> DessertTemplateRecipes { get; set; } = new List<DessertTemplateRecipe>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
