using System.Reflection;
using DessertsMakery.Persistence.Database.Seeding;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database;

internal sealed partial class DatabaseContext : DbContext
{
    private readonly IDatabaseSeeder _databaseSeeder;
    private static readonly Assembly ThisAssembly = typeof(DatabaseContext).Assembly;

    public DatabaseContext(DbContextOptions options, IDatabaseSeeder databaseSeeder)
        : base(options)
    {
        _databaseSeeder = databaseSeeder;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(ThisAssembly);

        _databaseSeeder.Seed(modelBuilder);
    }
}
