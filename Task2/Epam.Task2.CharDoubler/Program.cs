using System;
using System.Text;

namespace Epam.Task2.CharDoubler
{
    public class Program
    {
        public static void CharDoubler(string firstString, string secondString)
        {
            var sb = new StringBuilder(firstString);
            for (int i = 0; i < sb.Length; i++)
            {
                for (int j = 0; j < secondString.Length; j++)
                {
                    if (char.Equals(sb[i], secondString[j]))
                    {
                        sb.Insert(i + 1, sb[i++]);        
                        break;
                    }
                }
            }

            string thirdString = sb.ToString();
            Console.WriteLine($"The characters in both strings are doubled in the first string: " +
                $"{thirdString}");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the first string: ");
            string firstString = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the second string: ");
            string secondString = Console.ReadLine().ToLower();
            CharDoubler(firstString, secondString);
        }
    }
}
