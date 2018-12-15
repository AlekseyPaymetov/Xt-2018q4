using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._2_triangle
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            this.IsCorrect(a, b, c);

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Perimeter
        {
            get => this.a + this.b + this.c;
        }

        public double Area
        {
            get => Math.Sqrt((this.Perimeter / 2) * ((this.Perimeter / 2) - this.a) * ((this.Perimeter / 2) - this.b) * ((this.Perimeter / 2) - this.c));
        }

        private void IsCorrect(double a, double b, double c)
        {
            if (a <= 0)
            {
                throw new ArgumentException("a should be positive", nameof(this.a));
            }

            if (b <= 0)
            {
                throw new ArgumentException("b should be positive", nameof(this.b));
            }

            if (c <= 0)
            {
                throw new ArgumentException("c should be positive", nameof(this.c));
            }

            if (a >= b + c || b >= a + c || c >= a + b)
            {
                throw new ArgumentException("Entered sides do not form a triangle");
            }
        }
    }
}
