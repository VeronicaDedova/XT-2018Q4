using System;
using System.Collections.Generic;

namespace Epam.Task5.ToIntOrNotToInt
{
    public class Program
    {
        private const char Plus = '+';
        private const char Minus = '-';
        private const char MaxValue = '9';
        private const char MinValue = '0';
        private const char Separator = '.';
        private const char Exp = 'E';

        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"{Environment.NewLine}Enter the string to check if it is a positive integer" +
                $"{Environment.NewLine}(The decimal separator in the number is '.'):");
                string inputStr = Console.ReadLine().ToUpper();
                char[] str = inputStr.ToCharArray();
                int thereIsExp = 0;

                int countOfCharBeforeEps = 0;
                int countOfChareBeforeDot = 0;
                int plusIndex = 0;                

                Stack<char> symbolStack = new Stack<char>();

                for (int i = 0; i < str.Length; i++)
                {
                    symbolStack.Push(str[i]);
                }

                for (int i = str.Length; i >= 0; i--)
                {
                    if (symbolStack.Count != 0)
                    {
                        if ((i == 0) && (str[i] == Plus))
                        {
                            symbolStack.Pop();
                        }
                        else if ((symbolStack.Peek() <= MaxValue) && (symbolStack.Peek() >= MinValue))
                        {
                            symbolStack.Pop();
                        }
                        else
                        {
                            for (int j = str.Length - 1; j >= 0; j--)
                            {
                                if (str[j] == Exp)
                                {
                                    thereIsExp++;
                                    if ((symbolStack.Peek() == Plus) || (symbolStack.Peek() == Minus))
                                    {
                                        plusIndex = j + 2;
                                        symbolStack.Pop();                                        
                                        if (symbolStack.Count != 0)
                                        {
                                            symbolStack.Pop();
                                            if (symbolStack.Count != 0)
                                            {
                                                i++;
                                            }                                                
                                        }

                                        countOfCharBeforeEps = symbolStack.Count;
                                        break;
                                    }
                                    else if ((symbolStack.Peek() == Separator) && (str[i - 1] <= MaxValue) && (str[i - 1] >= MinValue))
                                    {
                                        symbolStack.Pop();
                                        if (symbolStack.Count != 0)
                                        {
                                            symbolStack.Pop();
                                            if (symbolStack.Count != 0)
                                            {
                                                i++;
                                            }
                                        }

                                        countOfChareBeforeDot = symbolStack.Count + 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                int sumBetween = countOfCharBeforeEps - countOfChareBeforeDot - 1;
                int sumBefore = countOfChareBeforeDot;

                char[] forClone = (char[])str.Clone();
                var tmp = new List<char>(forClone);
                if (plusIndex < forClone.Length)
                {
                    tmp.RemoveRange(0, plusIndex + 1);
                }            
                
                var back = tmp.ToArray();

                int afterExp = 0;
                for (int i = 0; i < back.Length; ++i)
                {
                    afterExp *= 10;
                    afterExp += back[i] - '0';
                }

                if ((symbolStack.Count == 0 && thereIsExp == 0) || (symbolStack.Count == 0 && sumBetween == afterExp) || (symbolStack.Count == 0 && sumBefore == afterExp))
                {
                    Console.WriteLine("The entered string is a positive integer.");
                }
                else
                {
                    Console.WriteLine("The entered string is NOT a positive integer.");
                }

                Console.WriteLine("Enter another number? (y/n) ");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
