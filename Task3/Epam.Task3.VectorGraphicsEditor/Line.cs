using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Line : Figure
    {    
        public Line(double x, double y, double x2, double y2) : base(x, y)
        {
            this.X2 = x2;
            this.Y2 = y2;
        }

        public Line() : base()
        {
            this.X2 = 1;
            this.Y2 = 1;
        }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public override void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine("You selected line");
                    Console.WriteLine($"{Environment.NewLine}Enter the coordinates of the beginning of the line.");
                    Console.Write("x1: ");
                    string sx = Console.ReadLine();
                    Console.Write("y1: ");
                    string sy = Console.ReadLine();
                    Console.WriteLine($"Enter the coordinates of the end of the line.");
                    Console.Write("x2: ");
                    string sx2 = Console.ReadLine();
                    Console.Write("y2: ");
                    string sy2 = Console.ReadLine();

                    if (double.TryParse(sx, out double x) &&
                        double.TryParse(sy, out double y) &&
                        double.TryParse(sx2, out double x2) &&
                        double.TryParse(sy2, out double y2))
                    {
                        Figure figure = new Line(x, y, x2, y2);
                        figure.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }

                    Console.WriteLine("Enter another line? (y/n) ");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another line? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public override void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Type of figure: line.");
            Console.WriteLine($"The coordinates of the beginning of the line: [{this.X}, {this.Y}]");
            Console.WriteLine($"The coordinates of the end of the line: [{this.X2}, {this.Y2}]");
            Console.WriteLine("====================");
        }
    }
}
