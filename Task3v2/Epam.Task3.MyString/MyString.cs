using System;

namespace Epam.Task3.MyString
{
    public class MyString
    {
        private char[] myString;

        public MyString(string str)
        {
            this.myString = str.ToCharArray();
        }

        public MyString()
        {
        }

        public int MyLength => this.myString.Length;

        public char this[int i]
        {
            get
            {
                return this.myString[i];
            }

            set
            {
                this.myString[i] = value;
            }
        }

        public int MyCompare(MyString myString2)
        {
            int myStringLength = this.myString.Length;
            int myString2Length = myString2.MyLength;
            if (myStringLength > myString2Length)
            {
                return 1;
            }
            else if (myStringLength < myString2Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public char[] MyToCharArray()
        {
            return this.myString;
        }

        public char[] MyConcat(MyString myString, MyString myString2)
        {
            char[] concat = new char[myString.MyLength + myString2.MyLength];
            for (int i = 0; i < myString.MyLength; i++)
            {
                concat[i] = myString[i];
            }

            for (int i = 0; i < myString2.MyLength; i++)
            {
                concat[i + myString.MyLength] = myString2[i];
            }

            return concat;
        }

        public int MyIndexOf(char ch)
        {
            for (int i = 0; i < this.myString.Length; i++)
            {
                if (this.myString[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public int MyLastIndexOf(char ch)
        {
            for (int i = this.myString.Length - 1; i >= 0; i--)
            {
                if (this.myString[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Create()
        {
            do
            {
                Console.Write("Enter the string: ");
                string str1 = Console.ReadLine();

                var mystr1 = new MyString(str1);

                Console.WriteLine($"Length of your string: {mystr1.MyLength}");
                Console.Write("Enter the second string to compare: ");
                string str2 = Console.ReadLine();

                var mystr2 = new MyString(str2);

                Console.WriteLine($"String comparison result: {mystr1.MyCompare(mystr2)}");

                char[] charArray = mystr1.MyToCharArray();
                Console.WriteLine($"String as char array:");
                for (int i = 0; i < charArray.Length; i++)
                {
                    Console.WriteLine($"{i}: {charArray[i]}");
                }

                char[] concat = mystr1.MyConcat(mystr1, mystr2);
                Console.WriteLine($"Concatenation of two strings:");
                for (int i = 0; i < concat.Length; i++)
                {
                    Console.Write(concat[i]);
                }

                Console.WriteLine($"{Environment.NewLine}Index of the first occurrence of a character in a string.");
                Console.WriteLine("Enter the character: ");
                string sch = Console.ReadLine();
                if (char.TryParse(sch, out char ch))
                {
                    Console.WriteLine($"The first occurrence: {mystr1.MyIndexOf(ch)}");
                    Console.WriteLine($"The last occurrence: {mystr1.MyLastIndexOf(ch)}");
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                }

                Console.WriteLine("Try again? (y/n) ");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
