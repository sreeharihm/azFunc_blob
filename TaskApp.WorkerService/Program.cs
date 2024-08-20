using Microsoft.Extensions.Configuration;
using TaskApp.WorkerService;
using TaskApp.Data;
using TaskApp.Data.Model;
using TaskApp.Data.Interface;
using TaskApp.Data.Repository;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices( (hostContext,services )=>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddHostedService<Worker>();
        services.AddHttpClient();
        services.AddDbContext<TaskDbContext>();
    })
    .Build();
host.Run();
