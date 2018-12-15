using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._4_number_array_sum
{
    public class Program
    {
        private static int[] intArray = new int[] { 1, 2, 3 };
        private static double[] doubleArray = new double[] { 1.2, 3.5, 6.8 };

        public static void Main(string[] args)
        {
            Console.Write("Some int array: ");
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write($"{intArray[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum of elements in int array: {intArray.MySum()}");
            Console.WriteLine();
            Console.Write("Some double array: ");
            for (int i = 0; i < doubleArray.Length; i++)
            {
                Console.Write($"{doubleArray[i]} ");
            }

            Console.WriteLine($"{Environment.NewLine}Sum of elements in double array: {doubleArray.MySum()}");
        }
    }
}
