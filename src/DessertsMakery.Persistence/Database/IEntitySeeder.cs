using DessertsMakery.Persistence.Models;

namespace DessertsMakery.Persistence.Database;

internal interface IEntitySeeder
{
    void Seed<TEntity>(TEntity entity)
        where TEntity : Entity;
}
