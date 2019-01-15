using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.NumberValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the number: ");
                string input = Console.ReadLine();

                Regex regexNormal = new Regex(@"^[+|-]?\d+[.|,]?\d*$");
                Regex regexScience = new Regex(@"^[+|-]?\d+[.|,]?\d*[e|E][+|-]?\d*$");

                if (regexNormal.IsMatch(input))
                {
                    Console.WriteLine("This number is in normal notation.");
                }
                else if (regexScience.IsMatch(input))
                {                    
                    Console.WriteLine("This number is in scientific notation.");
                }
                else
                {
                    Console.WriteLine("This is NOT a number.");
                }

                Console.WriteLine("Try again? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}