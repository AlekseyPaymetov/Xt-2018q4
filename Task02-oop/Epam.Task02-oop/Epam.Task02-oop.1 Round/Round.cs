using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._1_Round
{
    public class Round
    {
        private double x;
        private double y;
        private double radius;

        public Round(double x, double y, double r)
        {
            this.x = x;
            this.y = y;

            if (r <= 0)
            {
                throw new ArgumentException("Radius should be positive", nameof(this.radius));
            }

            this.radius = r;
        }

        public double Length
        {
            get => 2 * Math.PI * this.radius;
        }

        public double Area
        {
            get => Math.PI * this.radius * this.radius;
        }
    }
}
