using DessertsMakery.Persistence;
using DessertsMakery.Telegram.Application;
using DessertsMakery.Telegram.Infrastructure;
using DessertsMakery.Telegram.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddUserSecrets<Program>();
builder
    .Services.AddPersistence(builder.Configuration)
    .AddTelegramApplication(builder.Configuration)
    .AddTelegramInfrastructure(builder.Configuration)
    .AddHostedService<Worker>();

var host = builder.Build();
host.Run();
