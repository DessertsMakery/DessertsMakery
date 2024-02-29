using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database;

internal sealed partial class DatabaseContext : DbContext
{
    private static readonly Assembly ThisAssembly = typeof(DatabaseContext).Assembly;

    public DatabaseContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(ThisAssembly);
        modelBuilder.Seed<Contracts.Enums.RecipeDescriptionItemType, Models.Recipes.RecipeDescriptionItemType>(
            type => new Models.Recipes.RecipeDescriptionItemType { InternalId = type.Value, Name = type.Name }
        );
    }
}
