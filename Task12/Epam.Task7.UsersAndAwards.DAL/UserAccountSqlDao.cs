using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class UserAccountSqlDao : IUserAccountDAO
    {
        private const string AdminRole = "Admin";
        private const string UserRole = "User";

        private string connectionString;

        public UserAccountSqlDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public bool AppointAdmin(string userName)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AppointAdmin";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@role", AdminRole);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }

            return true;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            var userAcc = new List<UserAccount>();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllUserAccount";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    userAcc.Add(
                        new UserAccount
                        {
                            ID = (int)reader["id"],
                            UserName = (string)reader["userName"],
                            Password = (string)reader["password"],
                            Role = (string)reader["role"],
                        });
                }
            }

            return userAcc;
        }

        public string[] GetRolesForUsers(string userName)
        {
            var roles = new List<string>();
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetRolesForUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((string)reader["role"]);
                }
            }

            return roles.ToArray();
        }

        public bool Login(string userName, string password)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "Login";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@password", password);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                if (!reader.HasRows || userName == null || password == null)
                {
                    return false;
                }

                return true;
            }
        }

        public bool UniqName(string userName)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UniqueUserName";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return false;
                }

                return true;
            }
        }

        public bool Registration(string userName, string password)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "Registration";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("role", UserRole);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool RemoveAdmin(string userName)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AppointAdmin";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@role", UserRole);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}