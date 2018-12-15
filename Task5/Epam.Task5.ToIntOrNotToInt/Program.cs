using System;
using System.Collections.Generic;

namespace Epam.Task5.ToIntOrNotToInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string to check if it is a positive integer" +
                $"{Environment.NewLine}(The decimal separator in the number is '.'):");
            string str = Console.ReadLine();
            bool stringIsNumber = ExtensionString.IsNum(str);
            if (stringIsNumber)
            {
                Console.WriteLine("The entered string is a positive integer.");
            }
            else
            {
                Console.WriteLine("The entered string is NOT a positive integer.");
            }
        }
    }
}
