using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynchronousLoop
{
    public class RequestLoop
    {
        private static readonly HttpClient client;

        static RequestLoop()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/fibonacci");
        }

        public static void ExecuteLoop(List<int> fibonacciNumbers)
        {
            fibonacciNumbers.ForEach(number =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var fibonacciResponse = client.GetAsync("/" + number.ToString()).Result;
                var fibonacci = fibonacciResponse.Content.ReadAsStringAsync().Result;
                stopWatch.Stop();

                Console.WriteLine($"fibonacci in sequence {number} executed in {stopWatch.ElapsedMilliseconds} milliseconds with result {fibonacci}");
            });
        }

        public static void ExecuteParallelLoop(IEnumerable<int> fibonacciNumbers)
        {
            Parallel.ForEach(fibonacciNumbers, number =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var fibonacciResponse = client.GetAsync("/" + number.ToString()).Result;
                var fibonacci = fibonacciResponse.Content.ReadAsStringAsync().Result;
                stopWatch.Stop();

                Console.WriteLine($"fibonacci in sequence {number} executed in {stopWatch.ElapsedMilliseconds} milliseconds with result {fibonacci}");
            });
        }

        public static async Task ExecuteLoopAsync(List<int> fibonacciNumbers)
        {
            var tasks = new List<Task>();

            fibonacciNumbers.ForEach(number =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                tasks.Add(client.GetAsync("/" + number.ToString()).ContinueWith(async response =>
                {
                    var fibonacci = (await response).Content.ReadAsStringAsync();
                    stopWatch.Stop();
                    Console.WriteLine($"fibonacci in sequence {number} executed in {stopWatch.ElapsedMilliseconds} milliseconds with result {await fibonacci}");
                }));
            });

            await Task.WhenAll(tasks);
        }

        public static void ExecuteParallelLoopAsync(IEnumerable<int> fibonacciNumbers)
        {
            Parallel.ForEach(fibonacciNumbers, number =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                client.GetAsync("/" + number.ToString()).ContinueWith(async response =>
                {
                    var fibonacci = (await response).Content.ReadAsStringAsync();
                    stopWatch.Stop();
                    Console.WriteLine($"fibonacci in sequence {number} executed in {stopWatch.ElapsedMilliseconds} milliseconds with result {await fibonacci}");
                }).Wait();
            });
        }
    }
}
