using System.Collections.Generic;
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

        public void Update(int id, User user)
        {
            this.userDao.Update(id, user);
        }

        public bool Delete(int id)
        {
            return this.userDao.Delete(id);
        }

        public User GetById(int id)
        {
            return this.userDao.GetById(id);
        }

        public bool TryGetId(int id)
        {
            return this.userDao.TryGetId(id);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDao.GetAll();
        }

        public void AddImage(int id, byte[] img)
        {
            this.userDao.AddImage(id, img);
        }

        public bool DeleteImage(int id)
        {
            return this.userDao.DeleteImage(id);
        }
    }
}
