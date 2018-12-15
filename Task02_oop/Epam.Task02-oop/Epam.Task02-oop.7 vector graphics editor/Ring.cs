using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public class Ring : Shape, IArea
    {
        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            this.CheckInnerAndOuterRadius(innerRadius, outerRadius);
            this.InnerRound = new Round(x, y, innerRadius);
            this.OuterRound = new Round(x, y, outerRadius);
            this.Length = this.InnerRound.Length + this.OuterRound.Length;
            this.Area = this.OuterRound.Area - this.InnerRound.Area;
        }

        public double Area
        {
            get;
            private set;
        }

        private Round InnerRound
        {
            get;
            set;
        }

        private Round OuterRound
        {
            get;
            set;
        }

        public override void Show()
        {
            Console.WriteLine($"{Environment.NewLine}It's a ring");
            Console.WriteLine($"x: {this.InnerRound.X}");
            Console.WriteLine($"y: {this.InnerRound.Y}");
            Console.WriteLine($"Inner radius: {this.InnerRound.Radius}");
            Console.WriteLine($"Outer radius: {this.OuterRound.Radius}");
            Console.WriteLine("Length: {0:.###}", this.Length);
            Console.WriteLine("Area: {0:.###}", this.Area);
        }

        private void CheckInnerAndOuterRadius(double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius)
            {
                throw new ArgumentException("Outer radius should be bigger then inner radius");
            }
        }
    }
}
