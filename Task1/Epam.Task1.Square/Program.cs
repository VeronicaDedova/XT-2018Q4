using System;

namespace Epam.Task1.Square
{
    public class Program
    {
        public static void Square(int n)
        {
            if (n % 2 != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i == n / 2) && (j == n / 2))
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        public static void Main(string[] args)
        {
            int n = 0;

            Console.WriteLine("Enter the dimension of the square (an odd number):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out n))
            {
                Square(n);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
