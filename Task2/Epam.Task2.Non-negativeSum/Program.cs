using System;

namespace Epam.Task2.Non_negativeSum
{
    public class Program
    {
        public static void ArrayFill(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }

            ArrayOutput(arr);
        }

        public static void ArrayOutput(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        public static int NonNegativeSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimension of the array:");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int arrayLength) && arrayLength > 0)
            {
                int[] arr = new int[arrayLength];
                Console.WriteLine("Array: ");
                ArrayFill(arr);
                Console.WriteLine($"Sum of non-negative elements in the array: {NonNegativeSum(arr)}");                
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
