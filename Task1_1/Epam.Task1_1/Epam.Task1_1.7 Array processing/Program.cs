using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._7_Array_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 20;
            int[] array = new int[n];
            Random rng = new Random();
            Console.WriteLine("Initial array:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(n * 2);
                Console.Write(array[i]+" ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                int currentMin = array[i];
                int indexOfMin = i;

                for (int j = i; j < array.Length; j++)
                {
                    if (currentMin > array[j])
                    {
                        currentMin = array[j];
                        indexOfMin = j;
                    }
                }

                int begin = array[i];
                array[i] = array[indexOfMin];
                array[indexOfMin] = begin;
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Min in array: {0}. Max in array: {1}",array[0],array[array.Length-1]);
            Console.WriteLine(Environment.NewLine+"Sorted array:");
            for (int i=0; i<array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
