using System;

namespace Epam.Task1.Sequence
{
    public class Program
    {
        public static void Sequence(int n)
        {
            for (int i = 1; i < n + 1; i++)
            {
                Console.Write(i + " ");
            }            
        }

        public static void Main(string[] args)
        {
            int n = 0;

            Console.WriteLine("Enter the length of sequence:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out n))
            {
                Sequence(n);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }                
        }
    }
}
