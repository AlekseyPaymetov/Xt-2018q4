using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._4_number_array_sum
{
    public static class SumForArrayOfNumbers
    {
        public static sbyte MySum(this sbyte[] array)
        {
            sbyte sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static short MySum(this short[] array)
        {
            short sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static int MySum(this int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static long MySum(this long[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static byte MySum(this byte[] array)
        {
            byte sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static ushort MySum(this ushort[] array)
        {
            ushort sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static uint MySum(this uint[] array)
        {
            uint sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static ulong MySum(this ulong[] array)
        {
            ulong sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static float MySum(this float[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double MySum(this double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static decimal MySum(this decimal[] array)
        {
            decimal sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
