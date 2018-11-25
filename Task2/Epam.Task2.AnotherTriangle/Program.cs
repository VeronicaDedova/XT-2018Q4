using System;

namespace Epam.Task2.AnotherTriangle
{
    public class Program
    {
        public static void AnotherTriangle(int n)
        {
            int m = n * 2 - 1;

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

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the height of the triangle:");
            string s = Console.ReadLine();

            if (int.TryParse(s, out int n))
            {
                AnotherTriangle(n);
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
