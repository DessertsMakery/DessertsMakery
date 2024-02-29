using DessertsMakery.Persistence.Models.Orders;

namespace DessertsMakery.Persistence.Models.Cakes;

public sealed class CakeTemplate : Entity
{
    public string Name { get; set; } = null!;
    public decimal Weight { get; set; }

    public long CakeFamilyId { get; set; }
    public CakeFamily CakeFamily { get; set; } = null!;

    public long CakeWeightId { get; set; }
    public CakeWeight CakeWeight { get; set; } = null!;

    public ICollection<CakeTemplateRecipe> CakeTemplateRecipes { get; set; } = new List<CakeTemplateRecipe>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
