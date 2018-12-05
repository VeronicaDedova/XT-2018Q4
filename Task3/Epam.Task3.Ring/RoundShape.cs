using System;

namespace Epam.Task3.Ring
{
    public class RoundShape
    {
        private double r;

        public RoundShape()
        {
            this.X = 0;
            this.Y = 0;
            this.Radius = 1;
        }

        public RoundShape(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Radius
        {
            get => this.r;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius should be positive.");
                }
                else
                {
                    this.r = value;
                }
            }
        }
    }
}
