using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._5_Sum_of_Numbers
{
    public class Program
    {
        public static int ArithmeticProgression(int step, int maxValue)
        {
            int n = (maxValue - 1) / step;
            double result = (double)((step + (step * n)) / 2) * n;
            return (int)result;
        }

        public static void Main(string[] args)
        {
            const int A = 5;
            const int B = 3;
            const int N = 1000;
            int result = ArithmeticProgression(A, N) + ArithmeticProgression(B, N) - ArithmeticProgression(A * B, N);
            Console.WriteLine($"the sum of all numbers less than {N} times {A} and {B}: {result}");
        }
    }
}
