using DessertsMakery.Persistence.Models.Essentials;

namespace DessertsMakery.Persistence.Models.Consumables;

public sealed class Consumable : Entity
{
    public string Name { get; set; } = null!;
    public string? Firm { get; set; }
    public long ComponentId { get; set; }
    public Component Component { get; set; } = null!;

    public ICollection<ConsumablePackaging> ConsumablePackagings { get; set; } = new List<ConsumablePackaging>();
}
