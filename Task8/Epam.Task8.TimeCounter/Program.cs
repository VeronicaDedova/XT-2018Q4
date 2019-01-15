using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.TimeCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the string: ");
                string input = Console.ReadLine();

                Regex regex = new Regex(@"[0-1][0-9]|2[0-3]:[0-5][0-9]");
                MatchCollection matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    Console.WriteLine($"Time in the text occurs {matches.Count} times.");
                }
                else
                {
                    Console.WriteLine("Time in the text does not occur.");
                }

                Console.WriteLine("Try again? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
