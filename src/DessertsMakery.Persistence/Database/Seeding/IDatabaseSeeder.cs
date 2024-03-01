using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Seeding;

internal interface IDatabaseSeeder
{
    void Seed(ModelBuilder builder);
}
