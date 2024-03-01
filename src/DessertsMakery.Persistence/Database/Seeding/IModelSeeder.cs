using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Seeding;

internal interface IModelSeeder
{
    void Use(ModelBuilder builder);
}
