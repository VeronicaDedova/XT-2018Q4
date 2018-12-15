using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ISeekYou
{
    public class TimeMeasurements
    {
        public static long TimeMeasure(Action action)
        {
            var watch = new Stopwatch();
            long[] res = new long[50];

            for (int i = 0; i < res.Length; i++)
            {
                watch.Start();
                action();
                watch.Stop();
                res[i] = watch.ElapsedMilliseconds;
            }

            return Median(res);
        }

        public static long Median(long[] array)
        {
            Array.Sort(array);
            return array[(array.Length - 1) / 2];
        }        
    }
}
