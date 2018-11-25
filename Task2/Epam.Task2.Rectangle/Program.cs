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

            do
            {
                Console.WriteLine("Enter the lengths of the sides of the rectangle:");
                Console.Write("a = ");
            }
            while (!int.TryParse(Console.ReadLine(), out a));

            do
            {
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
