using System;

namespace Epam.Task1.Sequence
{
    class Program
    {
        static void Sequence(int N)
        {
            String seq = "";
            for (int i = 1; i < N+1; i++)
            {
                seq += i+" ";
            }
            Console.WriteLine(seq);
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
                Console.WriteLine("Incorrect input");
        }
    }
}
