using DessertsMakery.Persistence;
using DessertsMakery.Telegram.Infrastructure;
using DessertsMakery.Telegram.Worker;

var builder = Host.CreateApplicationBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

configuration.AddUserSecrets<Program>();
services
    .AddPersistence(builder.Configuration)
    .AddTelegramInfrastructure(builder.Configuration)
    .AddHostedService<Worker>();

var host = builder.Build();
host.Run();
