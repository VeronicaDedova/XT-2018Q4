using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class LinkTableSqlDao : IRepositoryDAO<LinkTable>
    {
        private string connectionString;

        public LinkTableSqlDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(LinkTable linkTable)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUserAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUser", linkTable.IdUser);
                command.Parameters.AddWithValue("@idAward", linkTable.IdAward);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteUserAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idAward", id);

                sqlConnection.Open();

                command.ExecuteNonQuery();

                return true;
            }
        }

        public IEnumerable<LinkTable> GetAll()
        {
            var linkTable = new List<LinkTable>();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllFromUserAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    linkTable.Add(
                        new LinkTable
                        {
                            IdUser =
                            (int)reader["idUser"],
                            IdAward = (int)reader["idAward"],
                        });
                }
            }

            return linkTable;
        }
        #region NotImplemented
        public void AddImage(int id, byte[] img)
        {
            throw new NotImplementedException();
        }

        public bool DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public LinkTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void GiveAward(int idU, int idA)
        {
            throw new NotImplementedException();
        }

        public bool TryGetId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, LinkTable item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
