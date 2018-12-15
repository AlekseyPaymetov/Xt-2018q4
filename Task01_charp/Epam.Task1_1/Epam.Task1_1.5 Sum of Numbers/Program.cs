using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._5_Sum_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum=0;
            const int number = 1000;

            //for (int i = 0, j = 0; j < number; i += 5, j += 3)
            //{
            //    if (i>=number)
            //    {
            //        sum += j;
            //    }
            //    else
            //    {
            //        sum += i + j;
            //    }
            //}

            // It's solution better than upper?
            for (int i = 0; i < number; i += 5)
            {
                sum += i;
            }

            for (int i = 0; i < number; i += 3)
            {
                sum += i;
            }

            Console.WriteLine($"the sum of all numbers less than {number} times 3 and 5: {sum}");
        }
    }
}
