using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Ring : Figure
    {
        private Round innerRadius;
        private Round outerRadius;

        public Ring(double x, double y, double outerR, double innerR) : base(x, y)
        {
            this.innerRadius = new Round { Radius = innerR };
            this.outerRadius = new Round { Radius = outerR };
            if (this.innerRadius.Radius >= this.outerRadius.Radius)
            {
                throw new ArgumentException("Inner radius cannot be greater than outer radius.");
            }
        }

        public Ring() : base()
        {            
        }

        public override void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine("You selected ring");
                    Console.WriteLine($"{Environment.NewLine}Enter the coordinates of the center of the ring.");
                    Console.Write("x: ");
                    string sx = Console.ReadLine();
                    Console.Write("y: ");
                    string sy = Console.ReadLine();
                    Console.WriteLine("Enter the outer radius of the ring:");
                    string souterR = Console.ReadLine();
                    Console.WriteLine("Enter the inner radius of the ring:");
                    string sinnerR = Console.ReadLine();

                    if (double.TryParse(sx, out double x) &&
                        double.TryParse(sy, out double y) &&
                        double.TryParse(sinnerR, out double innerR) &&
                        double.TryParse(souterR, out double outerR))
                    {
                        Figure figure = new Ring(x, y, outerR, innerR);
                        figure.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }

                    Console.WriteLine("Enter another ring? (y/n) ");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another ring? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public override void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Type of figure: ring.");
            Console.WriteLine($"The coordinates of the center of the ring: [{this.X}, {this.Y}]");
            Console.WriteLine($"Outer radius: {this.outerRadius.Radius}");
            Console.WriteLine($"Inner radius: {this.innerRadius.Radius}");
            Console.WriteLine($"Ring width: {this.outerRadius.Radius - this.innerRadius.Radius}");
            Console.WriteLine("====================");
        }
    }
}
