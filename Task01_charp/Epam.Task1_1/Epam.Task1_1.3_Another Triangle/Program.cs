using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._3_Another_Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter the number of strings (N>0): ");
            int.TryParse(Console.ReadLine(), out int n);
            if (n < 1)
            {
                Console.WriteLine("Incorrect input. N must be bigger then 0");
                return;
            }

            int maxLength = 1 + (2 * (n - 1));
            int startPosition = (maxLength / 2) + 1;
            int currentLenght = 1;

            for (int i = 1; i <= n; i++, currentLenght += 2, startPosition--)
            {
                for (int j = 1; j <= maxLength; j++)
                {
                    if (j < startPosition || j >= startPosition + currentLenght)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
