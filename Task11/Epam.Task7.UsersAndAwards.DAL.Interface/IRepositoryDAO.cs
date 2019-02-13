using System.Collections.Generic;

namespace Epam.Task7.UsersAndAwards.DAL.Interface
{
    public interface IRepositoryDAO<T> where T : class
    {
        void Add(T item);

        bool Update(int id, T item);

        bool Delete(int id);

        T GetById(int id);

        bool TryGetId(int id);

        IEnumerable<T> GetAll();

        void GiveAward(int idU, int idA);

        void AddImage(int id, byte[] img);

        bool DeleteImage(int id);
    }
}
