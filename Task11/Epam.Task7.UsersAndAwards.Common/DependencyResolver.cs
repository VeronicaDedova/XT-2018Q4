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
        private static IRepositoryDAO<LinkTable> linkTableDao;
        private static IUserAccountDAO userAccountDao;

        private static IRepositoryLogic<User> userLogic;
        private static IRepositoryLogic<Award> awardLogic;
        private static IRepositoryLogic<LinkTable> linkTableLogic;
        private static IUserAccountLogic userAccountLogic;

        public static IRepositoryDAO<User> UserDAO => userDao ?? (userDao = new UserDao());

        public static IRepositoryDAO<Award> AwardDAO => awardDao ?? (awardDao = new AwardDao());

        public static IRepositoryDAO<LinkTable> LinkTableDAO => linkTableDao ?? (linkTableDao = new LinkTableDao());

        public static IUserAccountDAO UserAccountDAO => userAccountDao ?? (userAccountDao = new UserAccountSqlDao());

        public static IRepositoryLogic<User> UserLogic => userLogic ?? (userLogic = new UserLogic(UserDAO));

        public static IRepositoryLogic<Award> AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDAO));

        public static IRepositoryLogic<LinkTable> LinkTableLogic => linkTableLogic ?? (linkTableLogic = new LinkTableLogic(LinkTableDAO));

        public static IUserAccountLogic UserAccountLogic => userAccountLogic ?? (userAccountLogic = new UserAccountLogic(UserAccountDAO));
    }
}
