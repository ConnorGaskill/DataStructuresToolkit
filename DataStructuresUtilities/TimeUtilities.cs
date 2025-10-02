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
    }
}
