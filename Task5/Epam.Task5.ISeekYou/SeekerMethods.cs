using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ISeekYou
{
    public static class SeekerMethods
    {
        public static int Seeker(this int[] array)
        {
            int count = 0;
            int maxCount = 0;
            int maxElem = 0;

            for (int i = 0; i < array.Length; i++)
            {
                count = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxElem = i;
                    }
                }
            }

            return array[maxElem];
        }

        public static int SeekerDelegateInstance(this int[] array, Func<int, int, bool> func)
        {
            int count = 0;
            int maxCount = 0;
            int maxElem = 0;

            if (func != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    count = 0;

                    for (int j = 0; j < array.Length; j++)
                    {
                        if (func(array[i], array[j]))
                        {
                            count++;
                        }

                        if (count > maxCount)
                        {
                            maxCount = count;
                            maxElem = i;
                        }
                    }
                }

                return array[maxElem];
            }
            else
            {
                throw new NullReferenceException("There should not be an empty function.");
            }
        }

        public static bool Func(int i, int j)
        {
            return i == j;
        }
    }
}
