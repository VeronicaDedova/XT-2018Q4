using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double x, double y, double width, double height) : base(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public Rectangle() : base()
        {
            this.Width = 1;
            this.Height = 2;
        }

        public double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive and different from zero.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive and different from zero.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public override void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine("You selected rectangle");
                    Console.WriteLine($"{Environment.NewLine}Enter the lengths of the sides of the rectangle.");
                    Console.Write("width: ");
                    string swidth = Console.ReadLine();
                    Console.Write("height: ");
                    string sheight = Console.ReadLine();
                    Console.WriteLine($"Enter the starting point on the coordinate system.");
                    Console.Write("x: ");
                    string sx = Console.ReadLine();
                    Console.Write("y: ");
                    string sy = Console.ReadLine();

                    if (double.TryParse(sx, out double x) &&
                        double.TryParse(sy, out double y) &&
                        double.TryParse(swidth, out double width) &&
                        double.TryParse(sheight, out double height))
                    {
                        Figure figure = new Rectangle(x, y, this.width, this.height);
                        figure.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }

                    Console.WriteLine("Enter another rectangle? (y/n) ");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another rectangle? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public override void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Type of figure: triangle.");
            Console.WriteLine($"Start on the coordinate plane at the point: [{this.X}, {this.Y}]");
            Console.WriteLine($"Width: {this.Width}");
            Console.WriteLine($"Height: {this.Height}");
            Console.WriteLine("====================");
        }
    }
}
