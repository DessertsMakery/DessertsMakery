using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Persistence.Database;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddContext(this IServiceCollection services, string folder)
    {
        var connection = $"Data Source={Path.Join(folder, "desserts_makery.db")}";
        return services.AddSqlite<DatabaseContext>(connection);
    }
}
