using System;
using System.Collections.Generic;

namespace Epam.Task5.CustomSort
{
    public class Program
    {
        private static Random random = new Random();

        public static void FillList(List<int> list)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(random.Next(10));
            }
        }

        public static void ShowList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var list = new List<int>();

            FillList(list);
            Console.WriteLine("Original array:");
            ShowList(list);

            Sort.SortArray(list, Sort.Compare);
            Console.WriteLine("Sorted <int> array:");
            ShowList(list);
        }
    }
}
