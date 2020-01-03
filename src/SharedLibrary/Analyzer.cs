using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public static class Analyzer
    {
        public static void Analyze(Action action, string actionName)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            action();
            stopWatch.Stop();

            Console.WriteLine($"\n\nTotal execution of {actionName} was in {stopWatch.ElapsedMilliseconds} milliseconds\n");
        }

        public static async Task AnalyzeAsync(Func<Task> action, string actionName)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await action();
            stopWatch.Stop();

            Console.WriteLine($"\n\nTotal execution of {actionName} was in {stopWatch.ElapsedMilliseconds} milliseconds\n");
        }
    }
}
