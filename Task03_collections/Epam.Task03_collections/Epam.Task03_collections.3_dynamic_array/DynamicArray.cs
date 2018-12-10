using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03_collections._3_dynamic_array
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        private const int DefaultSize = 8;

        public DynamicArray()
        {
            this.DynArray = new T[DefaultSize];
            this.Capacity = DefaultSize;
            this.Length = 0;
            this.Index = -1;
        }

        public DynamicArray(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Count of elements in array should be positive");
            }

            this.Capacity = n;
            this.Length = 0;
            this.Index = -1;
            this.DynArray = new T[n];
        }

        public DynamicArray(IEnumerable<T> collection) : this()
        {
            this.AddRange(collection);
        }

        public T[] DynArray
        {
            get;
            protected set;
        }

        public int Length
        {
            get;
            protected set;
        }

        public int Capacity
        {
            get;
            protected set;
        }

        public T Current
        {
            get => this.DynArray[this.Index];
        }

        object IEnumerator.Current
        {
            get => this.DynArray[this.Index];
        }

        protected int Index
        {
            get;
            set;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Length - 1)
                {
                    throw new ArgumentOutOfRangeException("Reference to a non-existent element");
                }

                return this.DynArray[index];
            }

            set
            {
                if (index < 0 || index > this.Length - 1)
                {
                    throw new ArgumentOutOfRangeException("Reference to a non-existent element");
                }

                this.DynArray[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            this.Reset();
        }

        public virtual bool MoveNext()
        {
            this.Index++;
            return this.Index < this.Length;
        }

        public void Reset()
        {
            this.Index = -1;
        }

        public void Add(T element)
        {
            if (this.Length < this.Capacity)
            {
                this.DynArray[this.Length] = element;
                this.Length++;
                return;
            }
            else
            {
                this.ChangeCapacity(0);
                this.Add(element);
            }
        }

        public void ShowDataOnConsole()
        {
            string separator = new string('-', 10);
            Console.WriteLine(separator);
            Console.WriteLine($"Length: {this.Length}");
            Console.WriteLine($"Capacity: {this.Capacity}");
            Console.WriteLine($"{Environment.NewLine}Elements:");
            foreach (var element in this)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(separator + Environment.NewLine);
        }

        public bool Remove(int indexOfDelete)
        {
            if (indexOfDelete < 0 || indexOfDelete > this.Length || this.Length < 1)
            {
                return false;
            }

            T[] part1 = new T[indexOfDelete];
            for (int i = 0; i < part1.Length; i++)
            {
                part1[i] = this.DynArray[i];
            }

            T[] part2 = new T[this.Length - indexOfDelete - 1];
            for (int i = 0; i < part2.Length; i++)
            {
                part2[i] = this.DynArray[indexOfDelete + 1 + i];
            }

            T[] newDynArray = new T[this.Length - 1];
            for (int i = 0; i < part1.Length; i++)
            {
                newDynArray[i] = part1[i];
            }

            for (int i = 0; i < part2.Length; i++)
            {
                newDynArray[indexOfDelete + i] = part2[i];
            }

            this.DynArray = new T[this.Capacity];
            for (int i = 0; i < newDynArray.Length; i++)
            {
                this.DynArray[i] = newDynArray[i];
            }

            this.Length--;
            return true;
        }

        public bool Insert(int index, T element)
        {
            if (index < 0 || index > this.Length)
            {
                throw new ArgumentOutOfRangeException("Insert element out of range");
            }

            if (this.Length + 1 > this.Capacity)
            {
                this.ChangeCapacity(0);
            }

            T[] part1 = new T[index + 1];
            for (int i = 0; i < part1.Length - 1; i++)
            {
                part1[i] = this.DynArray[i];
            }

            part1[part1.Length - 1] = element;

            T[] part2 = new T[this.Length - index];
            for (int i = 0; i < part2.Length; i++)
            {
                part2[i] = this.DynArray[index + i];
            }

            T[] newDynArray = new T[this.Length + 1];
            for (int i = 0; i < part1.Length; i++)
            {
                newDynArray[i] = part1[i];
            }

            for (int i = 0; i < part2.Length; i++)
            {
                newDynArray[index + 1 + i] = part2[i];
            }

            this.DynArray = new T[this.Capacity];
            for (int i = 0; i < newDynArray.Length; i++)
            {
                this.DynArray[i] = newDynArray[i];
            }

            this.Length++;
            return true;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (var item in collection)
            {
                count++;
            }

            if (count == 0)
            {
                return;
            }

            this.ChangeCapacity(count);
            foreach (var item in collection)
            {
                this.DynArray[this.Length] = item;
                this.Length++;
            }
        }

        private void ChangeCapacity(int countOfCapacityChange)
        {
            T[] previosArray = new T[this.Length];

            for (int i = 0; i < previosArray.Length; i++)
            {
                previosArray[i] = this.DynArray[i];
            }

            if (countOfCapacityChange == 0)
            {
                this.Capacity *= 2;
            }
            else
            {
                this.Capacity = previosArray.Length + countOfCapacityChange;
            }

            this.DynArray = new T[this.Capacity];
            for (int i = 0; i < previosArray.Length; i++)
            {
                this.DynArray[i] = previosArray[i];
            }
        }
    }
}
