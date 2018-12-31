using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Round : Figure
    {
        private double r;

        public Round(double x, double y, double r) : base(x, y)
        {
            this.Radius = r;
        }

        public Round() : base()
        {
            this.Radius = 1;
        }

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

        public override void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine("You selected round");
                    Console.WriteLine($"{Environment.NewLine}Enter the coordinates of the center of the round.");
                    Console.Write("x: ");
                    string sx = Console.ReadLine();
                    Console.Write("y: ");
                    string sy = Console.ReadLine();
                    Console.WriteLine("Enter the radius of the round:");
                    string sr = Console.ReadLine();

                    if (double.TryParse(sx, out double x) &&
                        double.TryParse(sy, out double y) &&
                        double.TryParse(sr, out double r))
                    {
                        Figure figure = new Round(x, y, this.r);
                        figure.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
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

        public override void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Type of figure: round.");
            Console.WriteLine($"The coordinates of the center of the round: [{this.X}, {this.Y}]");
            Console.WriteLine($"Radius: {this.Radius}");
            Console.WriteLine("====================");
        }
    }
}
