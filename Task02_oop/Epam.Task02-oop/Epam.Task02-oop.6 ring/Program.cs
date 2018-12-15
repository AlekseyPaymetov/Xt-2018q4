using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._6_ring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            double innerRadius = 6;
            double outerRadius = 9;
            Ring ring = new Ring(x, y, innerRadius, outerRadius);
            Console.WriteLine($"Inicial ring with x={x}, y={y}, inner radius={innerRadius}, outer radius={outerRadius}");
            Console.WriteLine("Area of the ring: {0:.000}", ring.Area);
            Console.WriteLine("Total length of the ring: {0:.000}", ring.TotalLength);
        }
    }
}
