using System;

namespace Epam.Task2.X_masTree
{
    public class Program
    {
        public static void Triangle(int n, int align)
        {
            int m = n * 2 - 1 + (align * 2);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j < ((m / 2) - i)) || (j > ((m / 2) + i)))
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }

                Console.WriteLine();
            }
        }

        public static void Tree(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                Triangle(i, n - i);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the height of the x-mas tree:");
            string s = Console.ReadLine();

            if (int.TryParse(s, out int n) && n > 0)
            {
                Tree(n);
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
