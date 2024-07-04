using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Common.Tests.Infrastructure.Sdk;

public static class Dependencies
{
    public static IServiceCollection AddSdkTestInfrastructure(
        this IServiceCollection services,
        Action<SdkBuilderConfiguration> action
    )
    {
        var configuration = new SdkBuilderConfiguration();
        action(configuration);
        services.TryAddSingleton(configuration);
        services.TryAddSingleton<SdkBuilder>();
        return services;
    }
}
