namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class Consumable : Entity
{
    public string Name { get; set; } = null!;
    public string? Firm { get; set; }
    public long IngredientNameId { get; set; }
    public IngredientName IngredientName { get; set; } = null!;

    public ICollection<ConsumablePackaging> ConsumablePackagings { get; set; } = new List<ConsumablePackaging>();
}