using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public class Rectangle : Shape, IArea
    {
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Length = (2 * Math.Abs(x1 - x2)) + (2 * Math.Abs(y1 - y1));
            this.Area = Math.Abs(x1 - x2) * Math.Abs(y1 - y2);
        }

        public double X1 { get; }

        public double X2 { get; }

        public double Y1 { get; }

        public double Y2 { get; }

        public double Area
        {
            get;
            private set;
        }

        public override void Show()
        {
            Console.WriteLine($"{Environment.NewLine}It's rectangle");
            Console.WriteLine($"x1: {this.X1}");
            Console.WriteLine($"y1: {this.Y1}");
            Console.WriteLine($"x2: {this.X2}");
            Console.WriteLine($"y2: {this.Y2}");
            Console.WriteLine($"perimeter: {this.Length}");
            Console.WriteLine($"area: {this.Area:.###}");
        }
    }
}
