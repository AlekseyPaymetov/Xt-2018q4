using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._5_to_int_or_not_to_int
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter string for check on int:");
                string someString;
                someString = Console.ReadLine();
                if (someString.IsInt())
                {
                    Console.WriteLine("Input string is Int.");
                }
                else
                {
                    Console.WriteLine("Input string is not Int.");
                }
            }
            catch
            {
                Console.WriteLine("Somthing wrong...");
            }
        }
    }
}
