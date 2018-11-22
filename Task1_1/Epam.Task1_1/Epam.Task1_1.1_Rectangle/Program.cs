using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._1_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input a: ");
            int.TryParse(Console.ReadLine(), out int a);
            if (a < 1)
            {
                Console.WriteLine("Input incorrect: a must be bigger then 0");
                return;
            }
            Console.Write("Please input b: ");
            int.TryParse(Console.ReadLine(), out int b);
            if (b < 1)
            {
                Console.WriteLine("Input incorrect: b must be bigger then 0");
                return;
            }

            Console.WriteLine("Square of rectagle: {0}", a * b);
        }
    }
}
