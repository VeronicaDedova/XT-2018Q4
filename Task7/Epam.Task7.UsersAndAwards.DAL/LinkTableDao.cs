using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class LinkTableDao : IRepositoryDAO<LinkTable>
    {
        private const string UsersAndAwardsFile = "usersAndAwards.txt";

        private static readonly string Path = Environment.CurrentDirectory + @"\usersAndAwards\";

        private static readonly List<LinkTable> RepositoryLinkTable = FileWithUsersAndAwards();

        public void Add(LinkTable linkTable)
        {
            RepositoryLinkTable.Add(linkTable);
            File.AppendAllLines(Path + UsersAndAwardsFile, new[] { linkTable.ToString() });
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LinkTable> GetAll()
        {
            return RepositoryLinkTable;
        }

        public LinkTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void GiveAward(int idU, int idA)
        {
            var listOfUsersAwards = File.ReadAllLines(Path + UsersAndAwardsFile);
        }

        public bool TryGetId(int id)
        {
            throw new NotImplementedException();
        }

        private static List<LinkTable> FileWithUsersAndAwards()
        {
            List<LinkTable> repositoryLinkTable = new List<LinkTable>();
            LinkTable linkTable;

            var lines = File.ReadAllLines(Path + UsersAndAwardsFile);
            foreach (var line in lines)
            {
                int idUser = int.Parse(line.Split(' ')[0]);
                int idAward = int.Parse(line.Split(' ')[1]);

                linkTable = new LinkTable
                {
                    IdUser = idUser,
                    IdAward = idAward,
                };

                repositoryLinkTable.Add(linkTable);
            }

            return repositoryLinkTable;
        }
    }
}
