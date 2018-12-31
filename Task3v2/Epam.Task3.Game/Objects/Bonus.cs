using System;

namespace Epam.Task3.Game
{
    public abstract class Bonus : Objects, IDraw
    {
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public abstract void Eaten();        
    }
}
