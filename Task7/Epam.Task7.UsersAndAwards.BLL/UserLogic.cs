using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.BLL.Interface;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL
{
    public class UserLogic : IRepositoryLogic<User>
    {
        private readonly IRepositoryDAO<User> userDao;

        public UserLogic(IRepositoryDAO<User> userDao)
        {
            this.userDao = userDao;
        }

        public void Add(User user)
        {
            this.userDao.Add(user);
        }

        public void Delete(int id)
        {
            this.userDao.Delete(id);
        }

        // public void Update(User user)
        // {
        //     this.userDao.Update(user);
        // }
        public User GetById(int id)
        {
            return this.userDao.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDao.GetAll();
        }
    }
}
