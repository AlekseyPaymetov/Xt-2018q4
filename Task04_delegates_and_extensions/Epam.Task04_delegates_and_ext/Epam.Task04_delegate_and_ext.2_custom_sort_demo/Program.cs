using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegate_and_ext._2_custom_sort_demo
{
    public class Program
    {
        private static string[] testArray = new string[] { "word12", "word2", "word1", "word4", "word0", "some_text", "a", "word2", "ab", "ac", "abc", "ab" };

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Unsort array:");
                ShowArrayOnConsole(testArray);
                Console.WriteLine("Sort array:");
                MySort(ref testArray, CustomSort);
                ShowArrayOnConsole(testArray);
            }
            catch
            {
                Console.WriteLine("Somthing wrong...");
            }
        }

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

        private static int CustomSort(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                return str1.CompareTo(str2);
            }

            return str1.Length - str2.Length;
        }
    }
}
