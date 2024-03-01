using DessertsMakery.Persistence.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IRecipeTables : ITables
{
    DbSet<Recipe> Recipes { get; set; }
    DbSet<RecipeDescriptionItem> RecipeDescriptionItems { get; set; }
    DbSet<RecipeDescriptionItemType> RecipeDescriptionItemTypes { get; set; }
    DbSet<RecipeIngredient> RecipeIngredients { get; set; }
}
