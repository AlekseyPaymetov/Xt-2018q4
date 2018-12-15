using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public class Circle : Shape
    {
        public Circle(double x, double y, double radius)
        {
            this.CheckOnPositive(radius);
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Length = 2 * Math.PI * radius;
        }

        public double X { get; }

        public double Y { get; }

        public double Radius { get; }

        public override void Show()
        {
            Console.WriteLine($"{Environment.NewLine}It's a circle");
            Console.WriteLine($"x: {this.X}");
            Console.WriteLine($"y: {this.Y}");
            Console.WriteLine($"Radius: {this.Radius}");
            Console.WriteLine("Length: {0:.###}", this.Length);
        }

        private void CheckOnPositive(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Var should be positive", nameof(number));
            }
        }
    }
}