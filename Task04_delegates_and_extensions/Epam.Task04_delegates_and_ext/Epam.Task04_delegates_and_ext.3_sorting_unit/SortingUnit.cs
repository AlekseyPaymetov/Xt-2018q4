using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._3_sorting_unit
{
    public class SortingUnit<T>
         where T : IComparable
    {
        private T[] array;
        private Func<T, T, int> func;

        public SortingUnit(T[] array)
        {
            this.array = array;
            this.func = this.MyCompare;
            this.SortIsOver += this.ShowCompleteOnConsole;
        }

        public SortingUnit(T[] array, Func<T, T, int> func)
        {
            this.array = array;
            this.func = func;
            this.SortIsOver += this.ShowCompleteOnConsole;
        }

        private delegate void EventHandler(object sender, EventArgs e);

        private event EventHandler SortIsOver;

        public void ShowOnConsole()
        {
            foreach (var item in this.array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public void MySortInThread()
        {
            Thread currentThread = new Thread(this.MySort);
            currentThread.Start();
        }

        public void ShowCompleteOnConsole(object sender, EventArgs e)
        {
            Console.WriteLine($"{Environment.NewLine}Sorting is over.");
            this.ShowOnConsole();
        }

        public void MySort()
        {
            if (this.array == null)
            {
                Console.WriteLine("Input array is empty");
                return;
            }

            for (int i = 0; i < this.array.Length; i++)
            {
                T min = this.array[i];
                int position = i;
                for (int j = i; j < this.array.Length; j++)
                {
                    if (this.func?.Invoke(this.array[j], min) < 0)
                    {
                        min = this.array[j];
                        position = j;
                    }
                }

                T startItem = this.array[i];
                this.array[i] = min;
                this.array[position] = startItem;
                Thread.Sleep(400);
            }

            this.SortIsOver?.Invoke(this, EventArgs.Empty);
        }

        private int MyCompare(T x, T y)
            => x.CompareTo(y);
    }
}
