using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using SharedLibrary;

namespace AsynchronousLoop
{
    public static class Loop
    {
        public static void ExecuteLoop(List<int> fibonacciNumbers)
        {
            fibonacciNumbers.ForEach(number =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                int fibonacci = number.GetNumberInSequence();
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
                int fibonacci = number.GetNumberInSequence();
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
                tasks.Add(number.GetNumberInSequenceAsync().ContinueWith((result) =>
                {
                    stopWatch.Stop();
                    Console.WriteLine($"fibonacci in sequence {number} executed in {stopWatch.ElapsedMilliseconds} milliseconds with result {result.Result}");
                }));
            });

            await Task.WhenAll(tasks);
        }

        public static void ExecuteParallelLoopAsync(IEnumerable<int> fibonacciNumbers)
        {
            Parallel.ForEach(fibonacciNumbers, async number =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                int fibonacci = await number.GetNumberInSequenceAsync();
                stopWatch.Stop();

                Console.WriteLine($"fibonacci in sequence {number} executed in {stopWatch.ElapsedMilliseconds} milliseconds with result {fibonacci}");
            });
        }
    }
}
