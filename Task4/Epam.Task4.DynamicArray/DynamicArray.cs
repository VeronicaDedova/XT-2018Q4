using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] array;
        private int capacity;

        public DynamicArray()
        {
            this.Capacity = 8;
            this.array = new T[this.Capacity];
            this.Length = this.array.Length;
        }

        public DynamicArray(int capacity)
        {
            this.array = new T[this.Capacity];
            this.Capacity = capacity;
            this.Length = this.array.Length;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.array = new T[collection.Count()];
            this.Length = collection.Count();
            this.Capacity = this.Length;
            collection.ToArray().CopyTo(this.array, 0);
        }

        public int Capacity
        {
            get => this.capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity cannot be negative.");
                }
                else
                {
                    this.capacity = value;
                }
            }
        }

        public int Length { get; private set; }

        public T this[int id]
        {
            get => this.array[id];

            set
            {
                if (id < 0 || id > this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.array[id] = value;
            }
        }

        public void Add(T item)
        {
           if (this.Length == this.Capacity)
            {                
                T[] buf = new T[this.Length + 1];
                this.Capacity *= 2;
                this.array.CopyTo(buf, 0);
                this.array = buf;
            }

            this.array[this.Length++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            for (int i = this.array.Length - 1; i > 0; i--)
            {
                if (this.array[i] != null)
                {
                    T[] arrayCopy = this.array;
                    this.array = new T[i + collection.Count() + 1];
                    for (int j = 0; j <= i; j++)
                    {
                        this.array[j] = arrayCopy[j];
                    }

                    for (int j = 0; j < collection.Count(); j++)
                    {
                        this.array[i + j + 1] = collection.ElementAt(j);
                    }

                    break;
                }
            }
        }

        public bool Remove(int position)
        {
            if (position >= this.Length || position < 0)
            {
                return false;
            }

            for (int i = position; i < this.Length - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            
            this.Length--;
            return true;
        }

        public bool Insert(T item, int index)
        {
            if (index < 0 || index >= this.Length)
            {
                return false;
            }

            if (this.Length == this.Capacity)
            {
                var buf = new T[this.Capacity * 2];
                this.array.CopyTo(buf, 0);
                this.array = buf;
            }

            for (int i = this.Length - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = item;
            this.Length++;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.array).GetEnumerator();
        }
    }
}
