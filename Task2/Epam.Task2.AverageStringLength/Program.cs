using System;

namespace Epam.Task2.AverageStringLength
{
    public class Program
    {
        public static void AverageStringLength(string str)
        {
            char[] ch = str.ToCharArray();
            int wordLength = 0;
            int sumOfLetters = 0;
            int countWords = 0;
            int average = 0;
            for (int i = 1; i < ch.Length; i++)
            {
                if (char.IsLetter(ch[i]))
                {
                    wordLength++;
                }

                if ((char.IsLetter(ch[i - 1]) && (char.IsSeparator(ch[i]) || char.IsPunctuation(ch[i]))) || i == ch.Length - 1)
                {
                    sumOfLetters += wordLength;
                    countWords++;
                    wordLength = 0;
                }
            }

            average = (sumOfLetters + 1) / countWords;
            Console.WriteLine($"Number of words: {countWords}");
            Console.WriteLine($"Number of letters: {sumOfLetters + 1}");
            Console.WriteLine($"The average length of a word in the entered string is {average}");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter any string: ");
            string str = Console.ReadLine();
            AverageStringLength(str);
        }
    }
}
