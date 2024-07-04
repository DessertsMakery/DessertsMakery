using System.Reflection;
using DessertsMakery.Common.Persistence.Mongo;
using DessertsMakery.Common.Utility.Extensions;
using DessertsMakery.Common.Utility.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DessertsMakery.Common.Persistence;

public static class Dependencies
{
    public const string DessertsMakeryPrefix = "DessertsMakery";

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        Assembly assembly,
        IConfiguration configuration
    )
    {
        services.AddConfiguration<MongoSettings>(configuration);
        services.TryAddSingleton<IMongoClient>(MongoClientFactory);
        services.TryAddScoped(MongoDatabaseFactory);
        services.TryAddTransient<ICollectionNamingStrategy, CollectionNamingStrategy>();
        services.TryAddTransient<IMongoCollectionProvider, MongoCollectionProvider>();
        services.TryAddMongoCollections(assembly);
        return services;
    }

    private static MongoClient MongoClientFactory(IServiceProvider provider)
    {
        var internalSettings = provider.GetRequiredService<IOptions<MongoSettings>>().Value;
        var clientSettings = MongoClientSettings.FromConnectionString(internalSettings.ConnectionString);
        return new MongoClient(clientSettings);
    }

    private static IMongoDatabase MongoDatabaseFactory(IServiceProvider provider)
    {
        var internalSettings = provider.GetRequiredService<IOptions<MongoSettings>>().Value;
        var mongoClient = provider.GetRequiredService<IMongoClient>();
        return mongoClient.GetDatabase(internalSettings.DatabaseName);
    }

    private static void TryAddMongoCollections(this IServiceCollection services, Assembly assembly)
    {
        var marker = typeof(MongoEntity);
        var assemblies = AssemblyHelper.LoadAssemblies(assembly, DessertsMakeryPrefix);
        var entityTypes = assemblies
            .SelectMany(x => x.DefinedTypes)
            .Where(MongoEntityIsPublicNonAbstractClass)
            .ToArray();
        foreach (var entityType in entityTypes)
        {
            var mongoCollectionType = typeof(IMongoCollection<>).MakeGenericType(entityType);
            services.TryAddScoped(mongoCollectionType, provider => provider.MongoCollectionFactory(entityType));
        }
        return;

        bool MongoEntityIsPublicNonAbstractClass(TypeInfo type) =>
            type is { IsClass: true, IsAbstract: false, IsPublic: true }
            && marker.IsAssignableFrom(type)
            && type != marker;
    }

    private static object MongoCollectionFactory(this IServiceProvider provider, Type entityType) =>
        provider.GetRequiredService<IMongoCollectionProvider>().Create(entityType);
}
