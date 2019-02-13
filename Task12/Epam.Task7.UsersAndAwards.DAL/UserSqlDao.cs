using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class UserSqlDao : IRepositoryDAO<User>
    {
        private string connectionString;

        public UserSqlDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(User user)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("patronymic", user.Patronymic);
                command.Parameters.AddWithValue("dateOfBirth", user.DateOfBirth);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void AddImage(int id, byte[] img)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddImageUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@image", img);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();

                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteImage(int id)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteImageUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();

                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllUsers";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(
                        new User
                        {
                            Id = (int)reader["id"],
                            FirstName = (string)reader["firstName"],
                            LastName = (string)reader["lastName"],
                            Patronymic = (string)reader["patronymic"],
                            DateOfBirth = (DateTime)reader["dateOfBirth"],
                            Img = reader["image"] as byte[],
                        });
                }
            }

            return users;
        }

        public User GetById(int id)
        {
            var user = new User();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetUserById";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = (int)reader["id"];
                    user.FirstName = (string)reader["firstName"];
                    user.LastName = (string)reader["lastName"];
                    user.Patronymic = (string)reader["patronymic"];
                    user.DateOfBirth = (DateTime)reader["dateOfBirth"];
                    user.Img = reader["image"] as byte[];
                }
            }

            if (user.Id == 0)
            {
                return null;
            }

            return user;
        }

        public void GiveAward(int idU, int idA)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GiveAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUser", idU);
                command.Parameters.AddWithValue("@idAward", idA);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public bool TryGetId(int id)
        {
            if (this.GetById(id) != null)
            {
                return true;
            }

            return false;
        }

        public bool Update(int id, User user)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("patronymic", user.Patronymic);
                command.Parameters.AddWithValue("dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("id", id);

                sqlConnection.Open();

                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
