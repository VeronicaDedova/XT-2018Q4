using System;
using System.Collections.Generic;
using System.Threading;

namespace Epam.Task5.SortingUnit
{
    public class SortingModule
    {
        private static object locker = new object();

        public event EventHandler SortingFinished;

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

        public void SortArray<T>(List<T> array, Func<T, T, int> func)
        {
            lock (locker)
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

            this.OnFinished(EventArgs.Empty);
        } 

        public void SortingInThread<T>(List<T> array, Func<T, T, int> func)
        {
            ThreadStart threadStart = delegate
            {
                this.SortArray(array, func);
            };

            var thread = new Thread(threadStart);
            thread.Start();
        }

        protected virtual void OnFinished(EventArgs e)
        {
            this.SortingFinished?.Invoke(this, e);
        }
    }
}
