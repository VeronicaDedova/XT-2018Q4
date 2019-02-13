using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL.Interface
{
    public interface IUserAccountDAO
    {
        IEnumerable<UserAccount> GetAll();

        bool Login(string userName, string password);

        bool UniqName(string userName);

        bool Registration(string userName, string password);

        bool AppointAdmin(string userName);

        bool RemoveAdmin(string userName);

        string[] GetRolesForUsers(string userName);
    }
}
