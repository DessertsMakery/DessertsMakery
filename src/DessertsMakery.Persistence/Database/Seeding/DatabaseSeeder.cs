using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Seeding;

internal sealed class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IEnumerable<IModelSeeder> _seeders;

    public DatabaseSeeder(IEnumerable<IModelSeeder> seeders)
    {
        _seeders = seeders;
    }

    public void Seed(ModelBuilder builder)
    {
        foreach (var seeder in _seeders)
        {
            seeder.Use(builder);
        }
    }
}
