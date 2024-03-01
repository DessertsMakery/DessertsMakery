using DessertsMakery.Persistence.Models.Essentials;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IEssentialTables
{
    DbSet<Addition> Additions { get; set; }
    DbSet<Component> Components { get; set; }
    DbSet<Measuring> Measurings { get; set; }
    DbSet<PackagingComponent> PackagingComponents { get; set; }
}
