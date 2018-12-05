using System;

namespace Epam.Task3.Game
{
    public interface IAction
    {
        void Move();

        void Attack();

        void Die();
    }
}
