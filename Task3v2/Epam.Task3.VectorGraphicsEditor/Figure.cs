using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public abstract class Figure
    {
        protected Figure(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        protected Figure()
        {
            this.X = 0;
            this.Y = 0;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public abstract void Create();

        public abstract void Show();
    }
}
