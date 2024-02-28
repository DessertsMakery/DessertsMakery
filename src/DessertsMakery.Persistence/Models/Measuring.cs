using DessertsMakery.Persistence.Models.Consumables;

namespace DessertsMakery.Persistence.Models;

public sealed class Measuring : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<ConsumablePackaging> ConsumablePackagings { get; set; } =
        new List<ConsumablePackaging>();
}
