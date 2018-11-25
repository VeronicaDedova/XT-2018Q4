using System;

namespace Epam.Task2.SumOfNumbers
{
    public class Program
    {
        public static int Sum()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"The sum of numbers that are less than 1000 and are multiples of 3 or 5 is {Sum()}");
        }
    }
}
