using System;
using System.Collections.Generic;
using System.Threading;

namespace Epam.Task5.SortingUnit
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
            var sort = new SortingModule();
            var list = new List<int>();

            FillList(list);
            Console.WriteLine("Original array:");
            ShowList(list);

            sort.SortArray(list, SortingModule.Compare);
            Console.WriteLine("Sorted array:");
            ShowList(list);
            sort.SortingFinished += Sort_SortingFinished;

            sort.SortingInThread(list, SortingModule.Compare);
            Console.WriteLine("Sorted in thread array:");
            ShowList(list);
        }

        private static void Sort_SortingFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Sorting finished.");
        }
    }
}
