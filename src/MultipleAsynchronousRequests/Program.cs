using SharedLibrary;
using System;
using System.Collections.Generic;

namespace MultipleAsynchronousRequests
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciNumbers = new List<int> { 30, 4, 33, 1, 8, 6, 10, 18, 21, 12, 9, 5, 29, 26, 24, 7 };

            Analyzer.AnalyzeAsync(() => Request.ExecuteAsync(fibonacciNumbers), "ExecuteAsync").Wait();

            Console.ReadKey();
        }
    }
}
