using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Figure figure = null;
            var figureType = FigureSelection.None;

            do
            {
                Console.WriteLine($"{Environment.NewLine}Select:{Environment.NewLine}" +
                $"\t1. {FigureSelection.Line} {Environment.NewLine}" +
                $"\t2. {FigureSelection.Circle} {Environment.NewLine}" +
                $"\t3. {FigureSelection.Rectangle} {Environment.NewLine}" +
                $"\t4. {FigureSelection.Round} {Environment.NewLine}" +
                $"\t5. {FigureSelection.Ring}");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selection) && selection > 0)
                {
                    if (selection <= 5)
                    {
                        figureType = (FigureSelection)selection;
                        switch (figureType)
                        {
                            case FigureSelection.Line:
                                figure = new Line();
                                figure.Create();
                                break;
                            case FigureSelection.Circle:
                                figure = new Circle();
                                figure.Create();
                                break;
                            case FigureSelection.Rectangle:
                                figure = new Rectangle();
                                figure.Create();
                                break;
                            case FigureSelection.Round:
                                figure = new Round();
                                figure.Create();
                                break;
                            case FigureSelection.Ring:
                                figure = new Ring();
                                figure.Create();
                                break;
                        }

                        Console.WriteLine("Enter another figure? (y/n) ");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input. The number should be from 1 to 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                    Console.WriteLine("Enter another figure? (y/n) ");
                    break;
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
