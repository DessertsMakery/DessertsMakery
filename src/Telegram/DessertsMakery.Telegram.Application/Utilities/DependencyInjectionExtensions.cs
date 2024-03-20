using System.Reflection;
using DessertsMakery.Telegram.Application.Utilities.Callbacks;
using DessertsMakery.Telegram.Application.Utilities.Localization;
using DessertsMakery.Telegram.Application.Utilities.Menu;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Telegram.Application.Utilities;

internal static class DependencyInjectionExtensions
{
    private static readonly Assembly ThisAssembly = typeof(DependencyInjectionExtensions).Assembly;

    internal static IServiceCollection AddTelegramUtilities(this IServiceCollection services) =>
        services.AddTelegramCallbackUtilities().AddTelegramLocalizationUtilities().AddTelegramMenuUtilities();
}
