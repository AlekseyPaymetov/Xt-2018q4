using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._8_No_positive
{
    class Program
    {
        static void ShowArray (int[,,]array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i,j,k]+" ");
                    }
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            const int n = 3;
            int[,,] array = new int[n,n,n];
            Random rng = new Random();
            for (int i=0; i<array.GetLength(0);i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i,j,k] = rng.Next(-100,100);
                    }
                }
            }

            Console.Write("Initial array:");
            ShowArray(array);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i,j,k]>0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }

            Console.Write(Environment.NewLine+"No positive array:");
            ShowArray(array);

        }
    }
}
