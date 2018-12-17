using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1._02_Simple
{
    public class Program
    {
        public static bool CheckForSimple(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {
            Console.Write("Please input positive number: ");

            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n < 1)
                {
                    Console.WriteLine("Input number must be bigger than 0.");
                }
                else
                {
                    if (CheckForSimple(n))
                    {
                        Console.WriteLine("Input number is simple.");
                    }
                    else
                    {
                        Console.WriteLine("Input number is not simple.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Input incorrect.");
            }
        }
    }
}
