using DessertsMakery.Common;
using DessertsMakery.Common.Wrappers;
using DessertsMakery.Persistence.Database;
using DessertsMakery.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DessertsMakery.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddWrappers()
            .AddConfiguration<PersistenceConfiguration>(configuration)
            .AddDatabaseContext(PathToDatabase)
            .AddRepositories();

    private static string PathToDatabase(IServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetRequiredService<IOptions<PersistenceConfiguration>>().Value;

        if (string.IsNullOrWhiteSpace(configuration.Folder))
        {
            throw new InvalidOperationException("Folder for database should always be defined in configuration");
        }

        if (string.IsNullOrWhiteSpace(configuration.FileName))
        {
            throw new InvalidOperationException("File name of database should always be defined in configuration");
        }

        return Path.Combine(configuration.Folder!, configuration.FileName!);
    }
}
