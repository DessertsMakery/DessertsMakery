using DessertsMakery.Persistence.Models.Desserts;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IDessertTables : ITables
{
    DbSet<DessertFamily> DessertFamilies { get; }
    DbSet<DessertFamilyWeight> DessertFamilyWeights { get; }
    DbSet<DessertPricing> DessertPricings { get; }
    DbSet<DessertTemplate> DessertTemplates { get; }
    DbSet<DessertTemplateRecipe> DessertTemplateRecipes { get; }
    DbSet<DessertWeight> DessertWeights { get; }
}
