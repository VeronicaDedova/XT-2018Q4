using System;

namespace Epam.Task2.NoPositive
{
    public class Program
    {
        public static void ArrayFill(int[,,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = rand.Next(-100, 100);
                    }
                }                
            }
        }

        public static void ArrayOutput(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write($"{arr[i, j, k]} ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void NoPositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimension of the array:");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int arrayLength) && arrayLength > 0)
            {
                int[,,] arr = new int[arrayLength, arrayLength, arrayLength];
                Console.WriteLine("Original array: ");
                ArrayFill(arr);
                ArrayOutput(arr);
                Console.WriteLine("An array in which positive numbers are replaced by zeros:");
                NoPositive(arr);
                ArrayOutput(arr);
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
