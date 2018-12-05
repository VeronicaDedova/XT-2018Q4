using System;

namespace Epam.Task3.Game
{
    public class PlayingField : Objects, IDraw
    {
        public PlayingField(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
