using System;

namespace Epam.Task2._2DArray
{
    public class Program
    {
        public static void ArrayFill(int[,] arr, int arrayLength)
        {
            Random rand = new Random();
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    arr[i, j] = rand.Next(10);
                }
            }
        }

        public static void ArrayOutput(int[,] arr, int arrayLength)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static int SumOfEvenPositions(int[,] arr, int arrayLength)
        {
            int sum = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    if (((i + j) % 2 == 0) || (i == 0 && j == 0))
                    {
                        sum += arr[i, j];
                    }
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
                int[,] arr = new int[arrayLength, arrayLength];
                Console.WriteLine("Original array: ");
                ArrayFill(arr, arrayLength);
                ArrayOutput(arr, arrayLength);
                Console.WriteLine($"The sum of the elements standing on even positions: {SumOfEvenPositions(arr, arrayLength)}");
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
