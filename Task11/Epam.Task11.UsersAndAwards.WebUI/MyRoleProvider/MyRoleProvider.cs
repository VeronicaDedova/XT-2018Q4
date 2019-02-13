using System;
using System.Web.Security;
using Epam.Task7.UsersAndAwards.BLL.Interface;
using Epam.Task7.UsersAndAwards.Common;

namespace Epam.Task11.UsersAndAwards.WebUI.MyRoleProvider
{
    public class MyRoleProvider : RoleProvider
    {
        private IUserAccountLogic userAccountLogic = DependencyResolver.UserAccountLogic;

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (roleName == "Admin")
            {
                return true;
            }

            if (roleName == "User")
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            return this.userAccountLogic.GetRolesForUsers(username);
        }

        #region NotImplemented

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}