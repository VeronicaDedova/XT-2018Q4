using System;

namespace Epam.Task1.Simple
{
    public class Program
    {
        public static void Simple(int n)
        {
            int count = 0;

            if ((n == 0) || (n == 1))
            {
                Console.WriteLine("The number is NOT simple");
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        count++;
                        break;
                    }
                }

                if (count != 0)
                {
                    Console.WriteLine("The number is NOT simple");
                }
                else
                {
                    Console.WriteLine("The number is simple");
                }
            }
        }

        public static void Main(string[] args)
        {
            int n = 0;

            Console.WriteLine("Enter the number:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out n))
            {
                Simple(n);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
