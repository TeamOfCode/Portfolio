using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CiagFibonacciego
{
    internal class Application
    {
        private static Stopwatch _stopWatch;
        private static TimeSpan _ts;

        private static void Main(string[] args)
        {
            RunAplicationTime();

            GetApliactionTimeTask();

            FibonacciGenerator.Generate(1000);
        }

        public static void RunAplicationTime()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        public static async Task GetApliactionTimeTask()
        {
            for (;;)
            {
                var returnValue = await GetAplicationTime();
                Console.WriteLine("czas: " + returnValue);
            }
        }

        public static Task<string> GetAplicationTime()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                _ts = _stopWatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    _ts.Hours, _ts.Minutes, _ts.Seconds,
                    _ts.Milliseconds/10);
                return elapsedTime;
            });
        }
    }
}