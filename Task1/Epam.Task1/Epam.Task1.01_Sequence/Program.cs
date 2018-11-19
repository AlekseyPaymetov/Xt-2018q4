using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1._01_Sequence
{
    class Program
    {
        static void Sequence_function (int n)
        { 
            for (int i = 1; i < n; i++)
            {
                Console.Write(i+", ");
            }
            Console.WriteLine(n);
        }

        static void Main(string[] args)
        {
           Console.Write("Please input positive number: ");
            
           if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n < 1)
                {
                    Console.WriteLine("Input number must be bigger than 1.");
                }
                else
                {
                    Sequence_function(n);
                }
            }
           else
            {
                Console.WriteLine("Input incorrect.");
            }
                
        }
    }
}
