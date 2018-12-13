using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._1_custom_sort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int[] testArray1 = new int[] { 1, 12, 8, 16, 2 };
                string[] testArray2 = new string[] { "Oleg", "Aleksey", "Artem", "Aleksey", "Ivan", "Mr.Medved" };
                Console.WriteLine("Unsort int array:");
                ShowArrayOnConsole(testArray1);
                MySort(ref testArray1, CompareInt);
                Console.WriteLine("Sort int array:");
                ShowArrayOnConsole(testArray1);
                Console.WriteLine("Unsort array of names:");
                ShowArrayOnConsole(testArray2);
                MySort(ref testArray2, (x, y) => x.CompareTo(y));
                Console.WriteLine("Sort array of names:");
                ShowArrayOnConsole(testArray2);
                MySort(ref testArray2, BiggestAleksey);
                Console.WriteLine("Sort array of names (use secret BiggestAleksey alghoritm):");
                ShowArrayOnConsole(testArray2);
            }
            catch
            {
                Console.WriteLine("Somthing wrong");
            }
        }

        private static int CompareInt(int x, int y)
            => x - y;

        private static int BiggestAleksey(string name1, string name2)
            => name1 == "Aleksey" ? 10 : -10;

        private static void MySort<T>(ref T[] array, Func<T, T, int> func)
        {
            if (array == null)
            {
                Console.WriteLine("Input array is empty");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                T min = array[i];
                int position = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (func?.Invoke(array[j], min) < 0)
                    {
                        min = array[j];
                        position = j;
                    }
                }

                T startItem = array[i];
                array[i] = min;
                array[position] = startItem;
            }
        }

        private static void ShowArrayOnConsole<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine($"{Environment.NewLine}");
        }
    }
}
