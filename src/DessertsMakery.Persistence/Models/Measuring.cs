using DessertsMakery.Persistence.Models.Cakes;
using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models;

public sealed class Measuring : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<ConsumablePackaging> ConsumablePackagings { get; set; } = new List<ConsumablePackaging>();
    public ICollection<RecipeIngredient> RecipePartIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<CakeWeight> CakeWeights { get; set; } = new List<CakeWeight>();
}
