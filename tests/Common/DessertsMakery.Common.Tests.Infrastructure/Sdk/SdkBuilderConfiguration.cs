using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Common.Tests.Infrastructure.Sdk;

public sealed class SdkBuilderConfiguration
{
    private readonly List<Action<IServiceCollection, IConfiguration>> _actions = [];

    internal void ApplyTo(IServiceCollection services, IConfiguration configuration)
    {
        foreach (var action in _actions)
        {
            action(services, configuration);
        }
    }

    public void Configure(Action<IServiceCollection, IConfiguration> action) => _actions.Add(action);
}
