using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task03_collections._3_dynamic_array;

namespace Epam.Task03_collections._4_dynamic_array
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(int n) : base(n)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {
        }

        public override bool MoveNext()
        {
            this.Index++;
            if (this.Index == this.Length)
            {
                this.Index = 0;
            }

            return true;
        }
    }
}
