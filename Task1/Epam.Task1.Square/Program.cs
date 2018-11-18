using System;

namespace Epam.Task1.Square
{
    class Program
    {
        static void Square(int N)
        {
            if (N%2 != 0)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if ((i == N/2) && (j == N/2))
                            Console.Write(" ");
                        else
                            Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Incorrect input");
        }
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Enter the dimension of the square (an odd number):");
            String input = Console.ReadLine();
            if (Int32.TryParse(input, out n))
            {
                Square(n);
            }
            else
                Console.WriteLine("Incorrect input");
        }
    }
}
