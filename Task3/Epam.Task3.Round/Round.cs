using System;

namespace Epam.Task3.Round
{
    public class Round
    {
        private double r;

        public Round(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
        }

        public Round()
        {
            this.X = 0;
            this.Y = 0;
            this.Radius = 1;
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

        public double Circumference => Math.PI * this.Radius * 2;
        
        public double GetArea => Math.PI * Math.Pow(this.Radius, 2);

        public void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Enter the coordinates of the center of the circle.");
                    Console.Write("x: ");
                    string sx = Console.ReadLine();
                    Console.Write("y: ");
                    string sy = Console.ReadLine();
                    Console.WriteLine("the radius of the circle:");
                    string sr = Console.ReadLine();

                    if (double.TryParse(sx, out double x) &&
                        double.TryParse(sy, out double y) &&
                        double.TryParse(sr, out double r))
                    {
                        var round = new Round(x, y, this.r);
                        round.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input.");
                    }

                    Console.WriteLine("Enter another round? (y/n) ");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another round? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine($"The coordinates of the center of the circle: [{this.X}, {this.Y}]");
            Console.WriteLine($"Radius: {this.Radius}");
            Console.WriteLine($"Circumference: {this.Circumference}");
            Console.WriteLine($"Area of a circle: {this.GetArea}");
            Console.WriteLine("====================");
        }
    }
}
