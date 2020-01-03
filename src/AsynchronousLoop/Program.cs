using System;
using System.Collections.Generic;
using SharedLibrary;

namespace AsynchronousLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciNumbers = new List<int> { 30, 4, 33, 1, 8, 6, 10, 18, 21, 12, 9, 5, 29, 26, 24, 7 };

            Console.WriteLine("Execution with requests? Y/N");
            var key = Console.ReadKey();
            
            if(key.Key == ConsoleKey.Y)
            {
                Analyzer.Analyze(() => RequestLoop.ExecuteLoop(fibonacciNumbers), "ExecuteLoop");
                Analyzer.Analyze(() => RequestLoop.ExecuteParallelLoop(fibonacciNumbers), "ExecuteParallelLoop");
                Analyzer.Analyze(() => RequestLoop.ExecuteParallelLoopAsync(fibonacciNumbers), "ExecuteParallelLoopAsync");
                Analyzer.AnalyzeAsync(async () => await RequestLoop.ExecuteLoopAsync(fibonacciNumbers), "ExecuteLoopAsync").Wait();

                return;
            }

            Analyzer.Analyze(() => Loop.ExecuteLoop(fibonacciNumbers), "ExecuteLoop");
            Analyzer.Analyze(() => Loop.ExecuteParallelLoop(fibonacciNumbers), "ExecuteParallelLoop");
            Analyzer.Analyze(() => Loop.ExecuteParallelLoopAsync(fibonacciNumbers), "ExecuteParallelLoopAsync");
            Analyzer.AnalyzeAsync(async () => await Loop.ExecuteLoopAsync(fibonacciNumbers), "ExecuteLoopAsync").Wait();

            Console.ReadKey();
        }
    }
}
