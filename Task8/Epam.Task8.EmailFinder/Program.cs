using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.EmailFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the string: ");
                string input = Console.ReadLine();

                string username = @"(\A|\s)([a-z0-9]+([-_\.a-z0-9])*)[a-z0-9]";
                string domainname = @"([a-z0-9]([-a-z0-9]*[a-z0-9])?\.)*([a-z]{2,6})";

                Regex regex = new Regex(username + "@" + domainname, RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    Console.WriteLine($"Found {matches.Count} email addresses:");
                    foreach (Match item in matches)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
                else
                {
                    Console.WriteLine("No email addresses found.");
                }

                Console.WriteLine("Try again? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
