using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class Program
    {
        public static void InputDate()
        {
            Console.WriteLine($"{Environment.NewLine}Enter the date and time (in the format {DateTime.Now})");
            string inputDate = Console.ReadLine();

            Regex regEx = new Regex(@"^\d{2}.\d{2}.\d{4} \d{2}:\d{2}:\d{2}");
            if (regEx.IsMatch(inputDate))
            {
                RollBack.Run();
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Select the program mode (1/2): "
                + $"{Environment.NewLine}1. Keep track of changes"
                + $"{Environment.NewLine}2. Roll back changes");

                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.D1)
                {
                    KeepTrack.Run();
                    Console.WriteLine($"{Environment.NewLine}Change of mode? (y/n)");
                }
                else if (key == ConsoleKey.D2)
                {
                    InputDate();
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}