using System;

namespace Epam.Task2.Rectangle
{
    public class Program
    {
        public static int Rectangle(int a, int b)
        {
            return a * b;
        }

        public static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int count = 0;

            Console.WriteLine("Enter the lengths of the sides of the rectangle:");
            do
            {
                count++;
                if (count > 1)
                {
                    Console.WriteLine("Incorrect input. The number must be an integer.");
                }

                Console.Write("a = ");                
            }
            while (!int.TryParse(Console.ReadLine(), out a));
            count = 0;

            do
            {
                count++;
                if (count > 1)
                {
                    Console.WriteLine("Incorrect input. The number must be an integer.");
                }

                Console.Write("b = ");
            }
            while (!int.TryParse(Console.ReadLine(), out b));

            if ((a <= 0) || (b <= 0))
            {
                Console.WriteLine($"Incorrect Input.{Environment.NewLine}The number must be positive and greater than zero.");
            }
            else
            {
                Console.WriteLine($"The area of the rectangle is {Rectangle(a, b)}");
            }
        }
    }
}
