using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public class Line : Shape
    {
        public Line(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Length = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double X1 { get; }

        public double X2 { get; }

        public double Y1 { get; }

        public double Y2 { get; }

        public override void Show()
        {
            Console.WriteLine($"{Environment.NewLine}It's a line.");
            Console.WriteLine($"x1: {this.X1}");
            Console.WriteLine($"y1: {this.Y1}");
            Console.WriteLine($"x2: {this.X2}");
            Console.WriteLine($"y2: {this.Y2}");
            Console.WriteLine("It's length: {0:.###}", this.Length);
        }
    }
}
