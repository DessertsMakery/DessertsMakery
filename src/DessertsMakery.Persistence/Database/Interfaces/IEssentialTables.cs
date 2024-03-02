using DessertsMakery.Persistence.Models.Essentials;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IEssentialTables : ITables
{
    DbSet<Addition> Additions { get; set; }
    DbSet<Component> Components { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    DbSet<Measuring> Measurings { get; set; }
    DbSet<PackagingComponent> PackagingComponents { get; set; }
}
