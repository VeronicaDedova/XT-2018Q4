using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.UsersAndAwards.BLL.Interface
{
    public interface IRepositoryLogic<T> where T : class
    {
        void Add(T item);

        void Delete(int id);

        // void Update(T item);
        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
