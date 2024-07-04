using DessertsMakery.Common.Tests.Infrastructure.Sdk;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Essentials.SDK.Integration.Tests;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSdkTestInfrastructure(builder =>
            builder.Configure((serviceCollection, configuration) => serviceCollection.AddEssentialsSdk(configuration))
        );
    }
}
