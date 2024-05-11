﻿namespace DessertsMakery.Expenses.Persistence.DependencyInjection;

public sealed class MongoSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
