﻿using System.Reflection;
using DessertsMakery.Common.Persistence;
using DessertsMakery.Common.Utility.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Expenses.SDK;

public static class Dependencies
{
    private static readonly Assembly ThisAssembly = typeof(Dependencies).Assembly;

    public static IServiceCollection AddExpensesSdk(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(ThisAssembly, configuration);
        services.AddServices(ThisAssembly);
        return services;
    }
}
