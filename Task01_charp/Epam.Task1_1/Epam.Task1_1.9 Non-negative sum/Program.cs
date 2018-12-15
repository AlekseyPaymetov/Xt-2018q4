using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._9_Non_negative_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            int[] array = new int[n];
            Random rng = new Random();

            Console.WriteLine("Initial array: ");
            for (int i=0; i<array.Length; i++)
            {
                array[i] = rng.Next(-10, 10);
                Console.Write($"{array[i]} ");
            }

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0) sum += array[i];
            }
            Console.WriteLine($"{Environment.NewLine}Sum of non-negative elements: {sum}");
        }
    }
}
