using System.Reflection;
using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Persistence.Database.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Persistence.Database;

internal static class DependencyInjectionExtensions
{
    private static readonly Assembly ThisAssembly = typeof(DependencyInjectionExtensions).Assembly;

    internal static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        Func<IServiceProvider, string> pathResolver
    ) => services.AddContextWith(pathResolver).AddSeeding(ThisAssembly).AddDatabaseInterfaces<DatabaseContext>();

    private static IServiceCollection AddContextWith(
        this IServiceCollection services,
        Func<IServiceProvider, string> pathResolver
    )
    {
        return services.AddDbContext<DatabaseContext>(WithCustomConnectionString);

        void WithCustomConnectionString(IServiceProvider provider, DbContextOptionsBuilder builder) =>
            builder.UseSqlite($"Data Source={pathResolver(provider)}");
    }
}
