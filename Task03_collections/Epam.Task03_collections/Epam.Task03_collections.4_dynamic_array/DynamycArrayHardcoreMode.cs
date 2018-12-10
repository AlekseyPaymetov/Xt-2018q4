using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task03_collections._3_dynamic_array;

namespace Epam.Task03_collections._4_dynamic_array
{
    public class DynamycArrayHardcoreMode<T> : DynamicArray<T>, ICloneable
    {
        public DynamycArrayHardcoreMode() : base()
        {
        }

        public DynamycArrayHardcoreMode(int n) : base(n)
        {
        }

        public DynamycArrayHardcoreMode(IEnumerable<T> collection) : base(collection)
        {
        }

        public new int Capacity
        {
            get
            {
                return base.Capacity;
            }

            set
            {
                if (value < this.Length)
                {
                    T[] newArray = new T[value];
                    for (int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = this.DynArray[i];
                    }

                    this.DynArray = new T[value];
                    for (int i = 0; i < newArray.Length; i++)
                    {
                        this.DynArray[i] = newArray[i];
                    }

                    this.Length = value;
                }

                base.Capacity = value;
            }
        }

        public new T this[int index]
        {
            get
            {
                if (index < -this.Length || index > this.Length - 1)
                {
                    throw new ArgumentOutOfRangeException("Reference to a non-existent element");
                }

                if (index < 0)
                {
                    return this.DynArray[this.Length + index];
                }

                return this.DynArray[index];
            }

            set
            {
                if (index < -this.Length || index > this.Length - 1)
                {
                    throw new ArgumentOutOfRangeException("Reference to a non-existent element");
                }

                if (index < 0)
                {
                    this.DynArray[this.Length + index] = value;
                }
                else
                {
                    this.DynArray[index] = value;
                }
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this.DynArray[i];
            }

            return array;
        }

        public object Clone()
        {
            DynamycArrayHardcoreMode<T> clone = new DynamycArrayHardcoreMode<T>(this.Capacity);
            clone.AddRange(this);
            return clone;
        }
    }
}
