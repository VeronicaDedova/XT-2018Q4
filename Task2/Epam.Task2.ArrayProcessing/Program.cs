using System;

namespace Epam.Task2.ArrayProcessing
{
    public class Program
    {
        public static void ArrayFill(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
            }
        }

        public static void ArrayOutput(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        public static void SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void Max(int[] arr)
        {
            SortArray(arr);
            Console.WriteLine($"Maximum array element is {arr[arr.Length - 1]}");
        }

        public static void Min(int[] arr)
        {
            SortArray(arr);
            Console.WriteLine($"Minimum array element is {arr[0]}");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimension of the array:");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int arrayLength) && arrayLength > 0)
            {
                int[] arr = new int[arrayLength];
                Console.WriteLine("Original array: ");
                ArrayFill(arr);
                ArrayOutput(arr);
                Console.WriteLine("Sorted array: ");
                SortArray(arr);
                ArrayOutput(arr);
                Max(arr);
                Min(arr);
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
