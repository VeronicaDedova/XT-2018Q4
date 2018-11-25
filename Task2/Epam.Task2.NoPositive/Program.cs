using System;

namespace Epam.Task2.NoPositive
{
    public class Program
    {
        public static void ArrayFill(int[,,] arr, int arrayLength)
        {
            Random rand = new Random();
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    for (int k = 0; k < arrayLength; k++)
                    {
                        arr[i, j, k] = rand.Next(-100, 100);
                    }
                }                
            }
        }

        public static void ArrayOutput(int[,,] arr, int arrayLength)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    for (int k = 0; k < arrayLength; k++)
                    {
                        Console.Write($"{arr[i, j, k]} ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void NoPositive(int[,,] arr, int arrayLength)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    for (int k = 0; k < arrayLength; k++)
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
                ArrayFill(arr, arrayLength);
                ArrayOutput(arr, arrayLength);
                Console.WriteLine("An array in which positive numbers are replaced by zeros:");
                NoPositive(arr, arrayLength);
                ArrayOutput(arr, arrayLength);
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
