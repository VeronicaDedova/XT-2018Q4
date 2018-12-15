using System;
using System.Collections.Generic;

namespace Epam.Task5.CustomSort
{
    public class Sort
    {
        public static void SortArray<T>(List<T> array, Func<T, T, int> func)
        {
            if (func != null)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    for (int j = i + 1; j < array.Count; j++)
                    {
                        if (func(array[i], array[j]) > 0)
                        {
                            T t = array[i];
                            array[i] = array[j];
                            array[j] = t;
                        }
                    }
                }
            }
            else
            {
                throw new NullReferenceException("There should not be an empty function.");
            }
        }

        public static int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (b > a)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int CompareString(string a, string b)
        {
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < b[i])
                    {
                        return -1;
                    }

                    if (a[i] > b[i])
                    {
                        return 1;
                    }
                }
            }
            else if (a.Length > b.Length)
            {
                return 1;
            }
            else 
            {
                return -1;
            }

            return -1;
        }
    }
}
