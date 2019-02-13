using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.BLL.Interface;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL
{
    public class UserAccountLogic : IUserAccountLogic
    {
        private readonly IUserAccountDAO userAccountDao;

        public UserAccountLogic(IUserAccountDAO userAccountDao)
        {
            this.userAccountDao = userAccountDao;
        }

        public bool AppointAdmin(string userName)
        {
            return this.userAccountDao.AppointAdmin(userName);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return this.userAccountDao.GetAll();
        }

        public string[] GetRolesForUsers(string userName)
        {
            return this.userAccountDao.GetRolesForUsers(userName);
        }

        public bool Login(string userName, string password)
        {
            return this.userAccountDao.Login(userName, password);
        }

        public bool Registration(string userName, string password)
        {
            return this.userAccountDao.Registration(userName, password);
        }

        public bool RemoveAdmin(string userName)
        {
            return this.userAccountDao.RemoveAdmin(userName);
        }

        public bool UniqName(string userName)
        {
            return this.userAccountDao.UniqName(userName);
        }
    }
}