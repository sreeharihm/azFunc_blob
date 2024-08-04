using Microsoft.Extensions.Configuration;
using TaskApp.WorkerService;
using TaskApp.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices( (hostContext,services )=>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddHostedService<Worker>();
        services.AddHttpClient();
        services.AddDataRegistration(configuration);
    })
    .Build();
host.Run();
