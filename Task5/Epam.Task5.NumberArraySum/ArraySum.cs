using System;

namespace Epam.Task5.NumberArraySum
{
    public static class ArraySum
    {
        public static int ArrSum(this int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double ArrSum(this double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static float ArrSum(this float[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static decimal ArrSum(this decimal[] array)
        {
            decimal sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static short ArrSum(this short[] array)
        {
            short sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static long ArrSum(this long[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static sbyte ArrSum(this sbyte[] array)
        {
            sbyte sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
