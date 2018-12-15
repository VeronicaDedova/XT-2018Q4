using System;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArray
{
    public class Program
    {
        private static Random rand = new Random();

        public static void FillArray(DynamicArray<int> array)
        {
            for (int i = 0; i < 8; i++)
            {
                array[i] = rand.Next(10);
            }
        }

        public static void ShowArray(DynamicArray<int> array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var array = new DynamicArray<int>();
            FillArray(array);
            Console.WriteLine("Original array:");
            ShowArray(array);

            array.Add(3);
            Console.WriteLine("Added 3 to the end of the array:");
            ShowArray(array);

            array.Insert(3, 0);
            Console.WriteLine("Insert element 3 on position with 0 index:");
            ShowArray(array);

            array.AddRange(new int[] { 1, 2, 3 });
            Console.WriteLine("Added IEnumerable<T> collection array { 1, 2, 3 }:");
            ShowArray(array);

            array.Remove(0);
            Console.WriteLine("Removed element with 0 index:");
            ShowArray(array);
        }
    }
}