using DessertsMakery.Persistence.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IRecipeTables
{
    DbSet<Recipe> Recipes { get; set; }
    DbSet<RecipeDescriptionItem> RecipeDescriptionItems { get; set; }
    DbSet<RecipeDescriptionItemType> RecipeDescriptionItemTypes { get; set; }
    DbSet<RecipeIngredient> RecipeIngredients { get; set; }
}
