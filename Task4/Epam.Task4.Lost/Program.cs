using System;
using System.Collections.Generic;

namespace Epam.Task4.Lost
{
    public class Program
    {
        public static LinkedList<int> Create(int n)
        {
            var list = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                list.AddLast(i);
            }

            return list;
        }

        public static void Show(LinkedList<int> list)
        {
            Console.Write("Stayed: ");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Remove(LinkedList<int> list)
        {
            var current = list.First;

            while (list.Count != 1)
            {
                if (current.Next != null)
                {
                    Console.WriteLine($"{current.Next.Value} removed");
                }
                else
                {
                    Console.WriteLine($"{list.First.Value} removed");
                }

                list.Remove(current.Next ?? list.First);
                current = current.Next ?? list.First;         
                Show(list);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"There are N people in the circle, numbered from 1 to N.{Environment.NewLine}When maintaining accounts in a circle, every second person is crossed out until one is left.");

            do
            {
                Console.Write($"{Environment.NewLine}Enter the number of people: ");
                string sn = Console.ReadLine();

                if (int.TryParse(sn, out int n))
                {
                    LinkedList<int> list = Create(n);
                    Remove(list);
                    Console.WriteLine("Try again? (y/n) ");
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                    Console.WriteLine("Try again? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
