using System.Collections.Generic;

namespace Epam.Task7.UsersAndAwards.BLL.Interface
{
    public interface IRepositoryLogic<T> where T : class
    {
        void Add(T item);

        void Update(int id, T item);

        bool Delete(int id);

        T GetById(int id);

        bool TryGetId(int id);

        IEnumerable<T> GetAll();

        void AddImage(int id, byte[] img);

        bool DeleteImage(int id);
    }
}
