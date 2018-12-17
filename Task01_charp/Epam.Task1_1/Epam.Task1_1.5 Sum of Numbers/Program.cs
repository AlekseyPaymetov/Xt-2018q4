using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._5_Sum_of_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long sum = 0;
            const int Number = 1000;
            for (int i = 0; i < Number; i += 5)
            {
                sum += i;
            }

            for (int i = 0; i < Number; i += 3)
            {
                sum += i;
            }

            Console.WriteLine($"the sum of all numbers less than {Number} times 3 and 5: {sum}");
        }
    }
}
