using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Common.Tests.Infrastructure.Sdk;

public static class SdkBuilderExtensions
{
    public static async Task<T> ResolveAsync<T>(
        this SdkBuilder sdkBuilder,
        CancellationToken cancellationToken = default
    )
        where T : notnull
    {
        var provider = await sdkBuilder.BuildAsync(cancellationToken).ConfigureAwait(false);
        return provider.GetRequiredService<T>();
    }
}
