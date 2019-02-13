using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class AwardSqlDao : IRepositoryDAO<Award>
    {
        private string connectionString;

        public AwardSqlDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(Award award)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", award.Title);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void AddImage(int id, byte[] img)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddImageAward";
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
                command.CommandText = "DeleteAward";
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
                command.CommandText = "DeleteImageAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();

                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var awards = new List<Award>();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllAwards";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awards.Add(
                        new Award
                        {
                            Id =
                            (int)reader["id"],
                            Title = (string)reader["title"],
                            Img = reader["image"] as byte[],
                        });
                }
            }

            return awards;
        }

        public Award GetById(int id)
        {
            var award = new Award();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAwardById";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    award.Id = (int)reader["id"];
                    award.Title = (string)reader["title"];
                    award.Img = reader["image"] as byte[];
                }
            }

            if (award.Id == 0)
            {
                return null;
            }

            return award;
        }

        public void GiveAward(int idU, int idA)
        {
            throw new NotImplementedException();
        }

        public bool TryGetId(int id)
        {
            if (this.GetById(id) != null)
            {
                return true;
            }

            return false;
        }

        public bool Update(int id, Award award)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", award.Title);
                command.Parameters.AddWithValue("id", id);

                sqlConnection.Open();

                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
