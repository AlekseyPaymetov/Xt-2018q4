using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._2_triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please input the first side of the triangle a: ");
            string input = Console.ReadLine();
            if (!double.TryParse(input, out double a))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            Console.Write("Please input the second side of the triangle b: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double b))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            Console.Write("Please input the third side of the triangle c: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double c))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            try
            {
                Triangle triangle = new Triangle(a, b, c);
                Console.WriteLine($"{Environment.NewLine}Perimeter of input triangle: {triangle.Perimeter}");
                Console.WriteLine("Area of input triangle: {0:.000}", triangle.Area);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
