using System;
using System.Collections.Generic;

namespace Epam.Task5.CustomSortDemo
{
    public class Program
    {
        public static void FillList(List<string> list)
        {
            list.Add("qwerty");
            list.Add("qwe");
            list.Add("b");
            list.Add("a");
            list.Add("ab");
            list.Add("ba");
        }

        public static void ShowList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var list = new List<string>();

            FillList(list);
            Console.WriteLine("Original array:");
            ShowList(list);

            CustomSort.Sort.SortArray(list, CustomSort.Sort.CompareString);
            Console.WriteLine("Sorted <string> array:");
            ShowList(list);
        }
    }
}
