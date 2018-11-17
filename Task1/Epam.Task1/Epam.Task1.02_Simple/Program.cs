using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1._02_Simple
{
    class Program
    {
        static bool Check_for_simple (int N)
        {
            for (int i = 2; i <= N / 2; i++)
                if (N % i == 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Please input positive number: ");

            if (int.TryParse(Console.ReadLine(), out int N))
                if (N < 2)
                    Console.WriteLine("Input number must be bigger than 1.");
                else
                    if (Check_for_simple(N))
                        Console.WriteLine("Input number is simple.");
                    else
                        Console.WriteLine("Input number is not simple.");
            else
                Console.WriteLine("Input incorrect.");
        }
    }
}
