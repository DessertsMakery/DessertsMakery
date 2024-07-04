using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MongoDb;

namespace DessertsMakery.Common.Tests.Infrastructure.Sdk;

public sealed class SdkBuilder(SdkBuilderConfiguration sdkBuilderConfiguration) : IAsyncDisposable
{
    private const string DatabaseName = "IntegrationTestsDatabase";
    private readonly ConcurrentBag<IAsyncDisposable> _asyncDisposables = [];
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();

    public async Task<IServiceProvider> BuildAsync(CancellationToken cancellationToken = default)
    {
        var container = new MongoDbBuilder().Build();
        await container.StartAsync(cancellationToken);
        _asyncDisposables.Add(container);
        var configuration = AddConfiguration(container);
        sdkBuilderConfiguration.ApplyTo(_serviceCollection, configuration);
        return _serviceCollection.BuildServiceProvider();
    }

    public async ValueTask DisposeAsync() =>
        await Task.WhenAll(_asyncDisposables.Select(x => x.DisposeAsync().AsTask()));

    private IConfiguration AddConfiguration(MongoDbContainer mongoDbContainer)
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(
                new KeyValuePair<string, string?>[]
                {
                    new("MongoSettings:DatabaseName", DatabaseName),
                    new("MongoSettings:ConnectionString", mongoDbContainer.GetConnectionString())
                }
            )
            .Build();
        _serviceCollection.AddScoped<IConfiguration>(_ => configuration);
        return configuration;
    }
}
