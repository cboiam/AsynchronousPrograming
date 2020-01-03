using SharedLibrary;
using System;

namespace ParallelProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Analyzer.Analyze(() => ParallelExecution.Execute(), "Execute");
            Analyzer.AnalyzeAsync(() => ParallelExecution.ExecuteAsync(), "ExecuteAsync").Wait();

            Console.ReadKey();
        }
    }
}
