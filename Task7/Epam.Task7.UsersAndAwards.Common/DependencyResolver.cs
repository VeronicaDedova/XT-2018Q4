using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.BLL;
using Epam.Task7.UsersAndAwards.BLL.Interface;
using Epam.Task7.UsersAndAwards.DAL;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.Common
{
    public class DependencyResolver
    {
        private static IRepositoryDAO<User> userDao;
        private static IRepositoryDAO<Award> awardDao;

        private static IRepositoryLogic<User> userLogic;
        private static IRepositoryLogic<Award> awardLogic;

        public static IRepositoryDAO<User> UserDAO => userDao ?? (userDao = new UserDao());

        public static IRepositoryDAO<Award> AwardDAO => awardDao ?? (awardDao = new AwardDao());

        public static IRepositoryLogic<User> UserLogic => userLogic ?? (userLogic = new UserLogic(UserDAO));

        public static IRepositoryLogic<Award> AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDAO));
    }
}
