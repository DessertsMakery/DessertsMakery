using System.Reflection;
using DessertsMakery.Telegram.Application.Utilities.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DessertsMakery.Telegram.Application.Utilities;

internal static class DependencyInjectionExtensions
{
    private static readonly Assembly ThisAssembly = typeof(DependencyInjectionExtensions).Assembly;

    internal static IServiceCollection AddTelegramUtilities(this IServiceCollection services)
    {
        services.TryAddTransient<IMenuMarkupBuilder, MenuMarkupBuilder>();
        services.TryAddScoped<IMenuSectionSelectedMessageSender, MenuSectionSelectedMessageSender>();
        services.TryAddAllMessageCreators();
        return services;
    }

    private static void TryAddAllMessageCreators(this IServiceCollection services)
    {
        var marker = typeof(IMenuSectionMessageCreator);
        var creators = ThisAssembly
            .DefinedTypes.Where(x => x is { IsClass: true, IsAbstract: false } && x.IsAssignableTo(marker))
            .ToArray();
        foreach (var creator in creators)
        {
            services.TryAddScoped(marker, creator);
        }
    }
}
