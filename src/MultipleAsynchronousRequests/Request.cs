using System;
using System.Collections.Generic;
using System.Linq;
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
            client.BaseAddress = new Uri("http://localhost:5000/api/fibonacci/");
        }

        public static async Task ExecuteAsync(List<int> fibonacciNumbers)
        {
            IEnumerable<Task<KeyValuePair<int, int>>> tasks = fibonacciNumbers.Select(number => client.GetAsync(number.ToString()).ContinueWith((response) =>
                {
                    var fibonacci = response.Result.Content.ReadAsStringAsync();
                    return new KeyValuePair<int, int>(number, int.Parse(fibonacci.Result));
                })
            );

            var result = await Task.WhenAny(tasks);
            Console.WriteLine($"fibonacci in sequence {(await result).Key} has the result {(await result).Value}");
        }
    }
}
