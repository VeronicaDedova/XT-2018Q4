using System;

namespace Epam.Task3.Ring 
{
    public class Ring 
    {
        private RoundShape innerRadius;
        private RoundShape outerRadius;

        public Ring(double x, double y, double r, double innerR)
        {
            this.innerRadius = new RoundShape { Radius = innerR };
            this.outerRadius = new RoundShape { Radius = r };
            if (this.innerRadius.Radius >= this.outerRadius.Radius)
            {
                throw new ArgumentException("Inner radius cannot be greater than outer radius.");
            }
        }

        public Ring()
        {
            this.X = 0;
            this.Y = 0;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double SumInOutСircumference => (Math.PI * this.outerRadius.Radius * 2) + (Math.PI * this.innerRadius.Radius * 2);

        public double SquareRing => Math.PI * (Math.Pow(this.outerRadius.Radius, 2) - Math.Pow(this.innerRadius.Radius, 2));

        public void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Enter the coordinates of the center of the ring.");
                    Console.Write("x: ");
                    string sx = Console.ReadLine();
                    Console.Write("y: ");
                    string sy = Console.ReadLine();
                    Console.WriteLine("Enter the outer radius of the ring:");
                    string souterR = Console.ReadLine();
                    Console.WriteLine("Enter the inner radius of the circle:");
                    string sinnerR = Console.ReadLine();

                    if (double.TryParse(sx, out double x) &&
                        double.TryParse(sy, out double y) &&
                        double.TryParse(sinnerR, out double innerR) &&
                        double.TryParse(souterR, out double outerR))
                    {
                        var ring = new Ring(x, y, outerR, innerR);
                        ring.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }

                    Console.WriteLine("Enter another user? (y/n) ");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another user? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine($"The coordinates of the center of the ring: [{this.X}, {this.Y}]");
            Console.WriteLine($"Outer radius: {this.outerRadius.Radius}");
            Console.WriteLine($"Inner radius: {this.innerRadius.Radius}");
            Console.WriteLine($"Sum of inner and outer circumference: {this.SumInOutСircumference}");
            Console.WriteLine($"Square of the ring: {this.SquareRing}");
            Console.WriteLine("====================");
        }
    }
}
