using System;

namespace Epam.Task2.FontAdjustment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var font = FontAdjustment.none;
            do
            {
                Console.WriteLine($"Label options: {font} {Environment.NewLine}Select:{Environment.NewLine}" +
                $"\t1. {FontAdjustment.bold} {Environment.NewLine}" +
                $"\t2. {FontAdjustment.italic} {Environment.NewLine}" +
                $"\t3. {FontAdjustment.underline}");
                if (int.TryParse(Console.ReadLine(), out int adjustment) && adjustment > 0)
                {
                    if (adjustment <= 3)
                    {
                        if (adjustment == 3)
                        {
                            adjustment = 4;
                        }

                        font ^= (FontAdjustment)adjustment;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input. The number should be from 1 to 3.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                    break;
                }
            }
            while (true);                
        }
    }
}
