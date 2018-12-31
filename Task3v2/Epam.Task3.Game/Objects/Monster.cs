using System;

namespace Epam.Task3.Game
{
    public abstract class Monster : Objects, IAction, IDraw
    {
        public abstract void Hunt();

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
