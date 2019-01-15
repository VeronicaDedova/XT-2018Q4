using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.HTMLReplacer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the string: ");
                string input = Console.ReadLine();

                Regex regex = new Regex(@"(<(.+?)>)|(</(.+?)>)");

                string result = regex.Replace(input, "_");
                Console.WriteLine(result);               

                Console.WriteLine("Try again? (y/n)");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
