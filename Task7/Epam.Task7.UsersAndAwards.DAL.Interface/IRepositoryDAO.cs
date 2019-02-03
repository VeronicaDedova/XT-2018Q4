using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.UsersAndAwards.DAL.Interface
{
    public interface IRepositoryDAO<T> where T : class
    {
        void Add(T item);

        bool Delete(int id);

        T GetById(int id);

        bool TryGetId(int id);

        IEnumerable<T> GetAll();

        void GiveAward(int idU, int idA);
    }
}
