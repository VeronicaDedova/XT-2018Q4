using System;

namespace Epam.Task3.Triangle
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            if ((a > b + c) || (b > a + c) || (c > a + b))
            {
                throw new ArgumentException("Incorrect input. Triangle does not exist.");
            }

            this.A = a;
            this.B = b;
            this.C = c;
        }

        public Triangle()
        {
            this.A = 1;
            this.B = 1;
            this.C = 1;
        }

        public double A
        {
            get => this.a;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive and different from zero.");
                }
                else
                {
                    this.a = value;
                }                    
            }
        }

        public double B
        {
            get => this.b;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive and different from zero.");
                }
                else
                {
                    this.b = value;
                }
            }
        }

        public double C
        {
            get => this.c;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be positive and different from zero.");
                }
                else
                {
                    this.c = value;
                }
            }
        }

        public double Perimetre => this.A + this.B + this.C;

        public double Square
        {
            get
            {
                double p = this.Perimetre / 2;
                return Math.Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C));
            }
        }

        public void Create()
        {
            do
            {
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Enter the sides of the triangle.");
                    Console.Write("a = ");
                    string sa = Console.ReadLine();
                    Console.Write("b = ");
                    string sb = Console.ReadLine();
                    Console.Write("c = ");
                    string sc = Console.ReadLine();

                    if (double.TryParse(sa, out double a) && double.TryParse(sb, out double b) && double.TryParse(sc, out double c))
                    {
                        var triangle2 = new Triangle(this.a, this.b, this.c);
                        triangle2.Show();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input.");
                    }

                    Console.WriteLine("Enter another user? (y/n) ");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another triangle? (y/n) ");
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public void Show()
        {
            Console.WriteLine("====================");
            Console.WriteLine($"Sides of a triangle: {this.A}, {this.B}, {this.C}");
            Console.WriteLine($"Perimetre: {this.Perimetre}");
            Console.WriteLine($"Square: {this.Square}");
            Console.WriteLine("====================");
        }
    }
}
