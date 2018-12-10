using System;
using System.Collections.Generic;

namespace Epam.Task4.WordFrequency
{
    public class Program
    {
        public static List<string> Create(string[] word)
        {
            var wordList = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                wordList.Add(word[i]);
            }

            return wordList;
        }

        public static void Show(List<string> wordList)
        {
            Console.WriteLine($"{Environment.NewLine}Single words: ");

            foreach (var item in wordList)
            {
                Console.WriteLine(item);
            }
        }

        public static void Frequency(List<string> wordList)
        {
            int wordCounter = 0;

            Console.WriteLine($"{Environment.NewLine}Word frequency: ");

            for (int i = 0; i < wordList.Count; i++)
            {
                for (int j = i; j < wordList.Count; j++)
                {
                    if (wordList[i].Equals(wordList[j]))
                    {
                        wordCounter++;
                    }

                    if (wordCounter > 1 && wordList[i].Equals(wordList[j]))
                    {
                        wordList.RemoveAt(j);
                        j--;
                    }
                }

                Console.WriteLine($"{wordList[i]}: {wordCounter}");
                wordCounter = 0;
            }
        }

        public static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter the english text: ");
                string text = Console.ReadLine().ToLower();

                char[] separator = new char[] { ' ', '.' };
                string[] word = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                List<string> wordList = Create(word);
                Show(wordList);
                Frequency(wordList);
                Console.WriteLine("Try again? (y/n) ");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);    
        }
    }
}
