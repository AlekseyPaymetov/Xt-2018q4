using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1._01_Sequence
{
    class Program
    {
        static string Sequence_function (int N)
        {
            string output="";
            for (int i = 1; i < N; i++)
                output += i.ToString() + ", ";
            output += N.ToString();
            return output;
            
        }

        static void Main(string[] args)
        {
           Console.Write("Please input positive number: ");
            
           if (int.TryParse(Console.ReadLine(), out int N))
                if (N<1)
                    Console.WriteLine("Input number must be bigger than 1.");
                else 
                    Console.WriteLine("Output: " + Sequence_function(N));
           else
                Console.WriteLine("Input incorrect.");
        }
    }
}
