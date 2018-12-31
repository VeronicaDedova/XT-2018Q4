using System;

namespace Epam.Task3.Game
{
    public class Player : Objects, IAction, IDraw
    {
        public void Circumvent()
        {
        }

        public void TakeBonus()
        {
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        void IAction.Move()
        {
        }

        void IAction.Attack()
        {
        }

        void IAction.Die()
        {
        }
    }
}
