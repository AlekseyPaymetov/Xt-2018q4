using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1._03_Square
{
    class Program
    {
        static void Draw_square (int N)
        {
            string line = new string('*',N);
            string halfOfLine = new string('*', N / 2);
            string middleLine = halfOfLine + " " + halfOfLine+"\n";
            string partWithoutSpace = "";

            for (int i = 0; i < N / 2; i++)
                partWithoutSpace += line + "\n";

            Console.WriteLine(partWithoutSpace+middleLine+partWithoutSpace);
        }

        static void Main(string[] args)
        {
            Console.Write("Please input positive odd number: ");

            if (int.TryParse(Console.ReadLine(), out int N))
                if (N < 2)
                    Console.WriteLine("Input number must be bigger than 1.");
                else
                    if (N % 2 == 0)
                    Console.WriteLine("Input number must be odd.");
                else
                    Draw_square(N);
            else
                Console.WriteLine("Input incorrect.");

        }
    }
}
