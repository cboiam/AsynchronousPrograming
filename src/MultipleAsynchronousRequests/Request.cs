using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultipleAsynchronousRequests
{
    public static class Request
    {
        private static readonly HttpClient client;

        static Request()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/fibonacci");
        }

        public static void ExecuteAsync(List<int> fibonacciNumbers)
        {
            var tasks = new List<Task>();

            foreach (int number in fibonacciNumbers)
            {
                bool finished = false;
                tasks.Add(client.GetAsync("/" + number.ToString()).ContinueWith(async response =>
                {
                    var fibonacci = (await response).Content.ReadAsStringAsync();
                    finished = true;
                    Console.WriteLine($"fibonacci in sequence {number} has the result {await fibonacci}");
                }));

                if (finished) return;
            }
        }
    }
}
