using System;

namespace Epam.Task1.Simple
{
    class Program
    {
        static void Simple(int n)
        {
            int count = 0;
            
            if ((n == 0) || (n == 1))
            {
                Console.WriteLine("The number is NOT simple");
            }
            
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        count++;
                        break;
                    }                    
                }
                
                if (count != 0)
                {
                    Console.WriteLine("The number is NOT simple");
                }
                
                else
                {
                    Console.WriteLine("The number is simple");
                }
                
            }                
        }
        static void Main(string[] args)
        {
            int n = 0;
            
            Console.WriteLine("Enter the number:");
            String input = Console.ReadLine();
            
            if (Int32.TryParse(input, out n))
            {
                Simple(n);
            }
            
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
