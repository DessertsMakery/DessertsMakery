using DessertsMakery.Persistence.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IRecipeTables : ITables
{
    DbSet<Recipe> Recipes { get; }
    DbSet<RecipeDescriptionItem> RecipeDescriptionItems { get; }
    DbSet<RecipeDescriptionItemType> RecipeDescriptionItemTypes { get; }
    DbSet<RecipeIngredient> RecipeIngredients { get; }
}
