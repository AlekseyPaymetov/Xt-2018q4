using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task02_oop._1_Round;

namespace Epam.Task02_oop._6_ring
{
    public class Ring
    {
        private Round innerRound;
        private Round outerRound;

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            this.CheckInnerAndOuterRadius(innerRadius, outerRadius);
            this.innerRound = new Round(x, y, innerRadius);
            this.outerRound = new Round(x, y, outerRadius);
        }

        public double X
        {
            get => this.innerRound.X;
        }

        public double Y
        {
            get => this.innerRound.Y;
        }

        public double InnerRadius
        {
            get => this.innerRound.Radius;
        }

        public double OuterRadius
        {
            get => this.outerRound.Radius;
        }

        public double Area
        {
            get => this.outerRound.Area - this.innerRound.Area;
        }

        public double TotalLength
        {
            get => this.outerRound.Length + this.innerRound.Length;
        }

        protected void CheckInnerAndOuterRadius(double innerRadius, double outerRadius)
        {
            if (innerRadius <= 0 || outerRadius <= 0)
            {
                throw new ArgumentException("Radius should be positive");
            }

            if (innerRadius >= outerRadius)
            {
                throw new ArgumentException("Inner radius should be smaller then outer radius");
            }
        }
    }
}
