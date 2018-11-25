using System;

namespace Epam.Task2.Triangle
{
    public class Program
    {
        public static void Triangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the height of the triangle:");
            string s = Console.ReadLine();

            if (int.TryParse(s, out int n))
            {
                Triangle(n);
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
