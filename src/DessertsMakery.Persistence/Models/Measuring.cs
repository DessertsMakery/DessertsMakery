using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Recipes;

namespace DessertsMakery.Persistence.Models;

public sealed class Measuring : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<ConsumablePackaging> ConsumablePackagings { get; set; } = new List<ConsumablePackaging>();

    public ICollection<RecipePartIngredient> RecipePartIngredients { get; set; } = new List<RecipePartIngredient>();
}
