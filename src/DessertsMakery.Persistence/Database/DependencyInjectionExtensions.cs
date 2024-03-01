using DessertsMakery.Persistence.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Persistence.Database;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        Func<IServiceProvider, string> pathResolver
    )
    {
        return services
            .AddDbContext<DatabaseContext>(
                (provider, builder) =>
                {
                    builder.UseSqlite();
#pragma warning disable EF1001
                    var extension = builder.Options.FindExtension<SqliteOptionsExtension>()!;
#pragma warning restore EF1001
                    var path = pathResolver(provider);
                    var connectionString = $"Data Source={path}";
                    extension.WithConnectionString(connectionString);
                }
            )
            .AddDatabaseInterfaces<DatabaseContext>();
    }

    private static IServiceCollection AddDatabaseInterfaces<TContext>(this IServiceCollection services)
        where TContext : notnull
    {
        var tablesMarker = typeof(ITables);
        var contextType = typeof(TContext);
        var tableInterfaces = contextType
            .GetInterfaces()
            .Where(x => x.IsAssignableTo(tablesMarker))
            .Except(new[] { tablesMarker });

        foreach (var tableInterface in tableInterfaces)
        {
            services.AddDatabaseInterface<TContext>(tableInterface);
        }

        return services;
    }

    private static void AddDatabaseInterface<TContext>(this IServiceCollection services, Type serviceType)
        where TContext : notnull =>
        services.TryAddScoped(serviceType, provider => provider.GetRequiredService<TContext>());
}
