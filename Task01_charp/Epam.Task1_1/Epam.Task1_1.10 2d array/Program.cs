﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._10_2d_array
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int N = 2;
            const int M = 3;
            int[][] array = new int[N][];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = new int[M];
            }

            Random rng = new Random();
            int sum = 0;

            Console.WriteLine("Initial array:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rng.Next(10);
                    Console.Write($"{array[i][j]} ");
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i][j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Sum of array elements in even positions: {sum}");
        }
    }
}
