using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worker
{
    public interface IWorkerService
    {
        Task Execute();
    }

    public class WorkerService : IWorkerService
    {
        private readonly HttpClient httpClient;
        public WorkerService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:8090/");
        }

        public async Task Execute()
        {
            while (true)
            {
                try
                {
                    await httpClient.PostAsync("action/create-user", null);
                    Console.WriteLine("Success: action/create-user");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Failed: action/create-user");
                }
                finally
                {
                    var rnd = new Random();
                    Thread.Sleep(rnd.Next(10000, 70000));
                }
            }
        }
    }
}