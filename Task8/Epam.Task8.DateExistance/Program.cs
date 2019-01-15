using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.DateExistance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the string: ");
                string input = Console.ReadLine();

                Regex regex = new Regex(@"(0[1-9]|1[0-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])-((1[0-9]|2[0-9])\d{2})");
                MatchCollection matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    Console.WriteLine($"The entered text contains the date in dd-mm-yyyy format {matches.Count} times");
                }
                else
                {
                    Console.WriteLine("The entered text DOES NOT contain the date in the format dd-mm-yyyy.");
                }

                Console.WriteLine("Try again? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
