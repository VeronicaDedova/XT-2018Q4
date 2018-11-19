using System;

namespace Epam.Task1.Sequence
{
    class Program
    {
        static void Sequence(int n)
        {
            for (int i = 1; i < n+1; i++)
            {
                Console.Write(i + " ");
            }
            
        }
        static void Main(string[] args)
        {
            int n = 0;
            
            Console.WriteLine("Enter the length of sequence:");
            String input = Console.ReadLine();
            
            if (Int32.TryParse(input, out n))
            {
                Sequence(n);
            }
            
            else
            {
                Console.WriteLine("Incorrect input");
            }
            
        }
    }
}
