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
            httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        public async Task Execute()
        {
            while (true)
            {
                await httpClient.PostAsync("action/create-user", null);
                Console.WriteLine("action/create-user called");
                var rnd = new Random();
                Thread.Sleep(rnd.Next(1000, 7000));
            }
        }
    }
}