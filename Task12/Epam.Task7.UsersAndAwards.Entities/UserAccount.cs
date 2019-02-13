using System;

namespace Epam.Task7.UsersAndAwards.Entities
{
    public class UserAccount
    {
        public UserAccount()
        {
        }

        public UserAccount(int id, string userName, string password, string role)
        {
            this.ID = id;
            this.UserName = userName;
            this.Password = password;
            this.Role = role;
        }

        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
