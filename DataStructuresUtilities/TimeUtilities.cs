using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresUtilities
{
    /// <summary>
    /// Utilities for timing
    /// </summary>
    public class TimeUtilities
    {
        /// <summary>
        /// Formats and prints a TimeSpan to the Console
        /// </summary>
        /// <param name="ts">The TimeSpan</param>
        public static void DisplayRuntime(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Time Taken: " + elapsedTime);
        }
        /// <summary>
        /// Formats a TimeSpan
        /// </summary>
        /// <param name="ts">The TimeSpan</param>
        /// <returns></returns>
        public static string FormatRuntime(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsedTime;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TimeSpan RunWithStopwatch(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action.Invoke();
            sw.Stop();
            return sw.Elapsed;
        }
        public static void PrintFastest(params KeyValuePair<string, TimeSpan>[] timeSpans)
        {
            if (timeSpans == null || timeSpans.Length == 0)
            {
                Console.WriteLine("No TimeSpans provided.");
                return;
            }

            var fastest = timeSpans.OrderBy(ts => ts.Value).First();

            Console.WriteLine($"Fastest: {fastest.Key} - {fastest.Value}");

            foreach (var ts in timeSpans)
            {
                if (ts.Key == fastest.Key) continue;

                var difference = ts.Value - fastest.Value;
                Console.WriteLine($"{fastest.Key} was faster than {ts.Key} by {difference}");
            }
        }
    }
}
