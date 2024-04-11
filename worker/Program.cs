// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using worker;

Console.WriteLine("Worker is ready ...");

var builder = new HostBuilder()
           .ConfigureServices((hostContext, services) =>
           {
               services.AddHttpClient();
               services.AddTransient<IWorkerService, WorkerService>();
           }).UseConsoleLifetime();

var host = builder.Build();


var workerService = host.Services.GetRequiredService<IWorkerService>();

await workerService.Execute();

Console.WriteLine("Worker is shutting down ...");
