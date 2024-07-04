using System.Diagnostics.CodeAnalysis;
using DessertsMakery.Common.Tests.Infrastructure.Sdk;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Essentials.SDK.Integration.Tests;

public sealed class Startup
{
    [SuppressMessage("Performance", "CA1822:Mark members as static")]
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSdkTestInfrastructure(builder =>
            builder.Configure((serviceCollection, configuration) => serviceCollection.AddEssentialsSdk(configuration))
        );
    }
}
