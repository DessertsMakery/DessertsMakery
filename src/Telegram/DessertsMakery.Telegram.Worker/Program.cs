using DessertsMakery.Persistence;
using DessertsMakery.Telegram.Worker;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(
    (context, services) => services.AddPersistence(context.Configuration).AddHostedService<Worker>()
);
var host = builder.Build();
host.Run();
