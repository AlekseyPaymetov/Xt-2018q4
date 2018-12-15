using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._1_Round
{
    public class Round
    {
        public Round(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;

            if (r <= 0)
            {
                throw new ArgumentException("Radius should be positive", nameof(this.Radius));
            }

            this.Radius = r;
            this.Length = 2 * Math.PI * this.Radius;
            this.Area = Math.PI * this.Radius * this.Radius;
        }

        public double X { get; }

        public double Y { get; }

        public double Radius { get; }

        public double Length
        {
            get;
            private set;
        }

        public double Area
        {
            get;
            private set;
        }
    }
}
