using System;

namespace Epam.Task5.NumberArraySum
{
    public class Program
    {
        private static Random random = new Random();

        public static void FillIntArr(int[] arr)
        {
            for (int i = 0; i < 5; i++)
            {
                arr[i] = random.Next(10);
            }
        }

        public static void ShowIntArr(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[] a = new int[5];
            FillIntArr(a);
            Console.WriteLine("Array <int>:");
            ShowIntArr(a);
            int sum = ArraySum.ArrSum(a);
            Console.WriteLine("The array of numbers is extended by the method allowing to find their sum:");
            Console.WriteLine(sum);
        }
    }
}
