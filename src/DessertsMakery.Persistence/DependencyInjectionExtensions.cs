using DessertsMakery.Common;
using DessertsMakery.Persistence.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DessertsMakery.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) =>
        services.AddConfiguration<PersistenceConfiguration>(configuration).AddDatabaseContext(PathToDatabase);

    private static string PathToDatabase(IServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetRequiredService<IOptions<PersistenceConfiguration>>().Value;
        var path = Path.Combine(configuration.Folder!, configuration.FileName);
        return path;
    }
}
