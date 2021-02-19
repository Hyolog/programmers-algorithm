using System;
using System.Diagnostics;

namespace ProgrammersAlgorithmTest.Library
{
    public static class TimeChecker
    {
        public static TimeSpan GetRunningTime(Action action, int repeat)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < repeat; i++)
                action.Invoke();

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
