using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._12_Char_double
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input 1st string: ");
            char[] str = Console.ReadLine().ToCharArray();
            Console.Write("Please input 2nd string: ");
            char[] strCreateDouble = Console.ReadLine().ToCharArray();
            StringBuilder outputString = new StringBuilder();

            for (int i=0; i<str.Length; i++)
            {
                bool symbolFind = false;
                for (int j=0; j<strCreateDouble.Length; j++)
                {
                    if (str[i]==strCreateDouble[j])
                    {
                        symbolFind = true;
                        break;
                    }
                }

                outputString.Append(str[i]);
                if (symbolFind) outputString.Append(str[i]);
            }

            Console.WriteLine($"Result string: {outputString}");

        }
    }
}
