﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1._03_Square
{
    class Program
    {
        static void Draw_square (int n)
        {
            for (int i=0; i<n;i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (i == j && i == n / 2)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            Console.Write("Please input positive odd number: ");

            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n < 2)
                {
                    Console.WriteLine("Input number must be bigger than 1.");
                }
                else
                {
                    if (n % 2 == 0)
                    {
                        Console.WriteLine("Input number must be odd.");
                    }
                    else
                    {
                        Draw_square(n);
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
