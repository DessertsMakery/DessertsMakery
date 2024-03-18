using DessertsMakery.Persistence.Models.Essentials;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IEssentialTables : ITables
{
    DbSet<Addition> Additions { get; }
    DbSet<Component> Components { get; }
    DbSet<Ingredient> Ingredients { get; }
    DbSet<Measuring> Measurings { get; }
    DbSet<PackagingComponent> PackagingComponents { get; }
}
