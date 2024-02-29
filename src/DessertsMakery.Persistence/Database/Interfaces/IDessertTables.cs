using DessertsMakery.Persistence.Models.Desserts;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IDessertTables
{
    DbSet<DessertFamily> DessertFamilies { get; set; }
    DbSet<DessertFamilyWeight> DessertFamilyWeights { get; set; }
    DbSet<DessertPricing> DessertPricings { get; set; }
    DbSet<DessertTemplate> DessertTemplates { get; set; }
    DbSet<DessertTemplateRecipe> DessertTemplateRecipes { get; set; }
    DbSet<DessertWeight> DessertWeights { get; set; }
}
