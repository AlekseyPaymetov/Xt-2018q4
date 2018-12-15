using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public class Round : Circle, IArea
    {
        public Round(double x, double y, double radius)
            : base(x, y, radius)
        {
            this.Area = Math.PI * this.Radius * this.Radius;
        }

        public double Area
        {
            get;
            private set;
        }

        public override void Show()
        {
            Console.WriteLine($"{Environment.NewLine}It's a round");
            Console.WriteLine($"x: {this.X}");
            Console.WriteLine($"y: {this.Y}");
            Console.WriteLine($"Radius: {this.Radius}");
            Console.WriteLine("Length: {0:.###}", this.Length);
            Console.WriteLine("Area: {0:.###}", this.Area);
        }
    }
}
