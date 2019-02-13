using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.UsersAndAwards.DAL.Interface
{
    public interface IUserAccountDAO
    {
        bool Login(string userName, string password);

        bool Registration(string userName, string password);

        bool AppointAdmin(string userName);

        bool RemoveAdmin(string userName);
    }
}
