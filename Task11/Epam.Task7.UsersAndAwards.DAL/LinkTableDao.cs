using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class LinkTableDao : IRepositoryDAO<LinkTable>
    {
        private const string UsersAndAwardsFile = "usersAndAwards.txt";

        private static readonly string Path = AppContext.BaseDirectory + @"\..\usersAndAwards\";

        private static readonly List<LinkTable> RepositoryLinkTable = FileWithUsersAndAwards();

        public void Add(LinkTable linkTable)
        {
            RepositoryLinkTable.Add(linkTable);
            File.AppendAllLines(Path + UsersAndAwardsFile, new[] { linkTable.ToString() });
        }

        public bool Delete(int id)
        {
            List<LinkTable> newLinkTable = new List<LinkTable>();

            foreach (var link in RepositoryLinkTable)
            {
                if (link.IdAward != id)
                {
                    newLinkTable.Add(link);
                }
            }

            var afterDeleted = newLinkTable.Select(x => x.ToString()).ToArray();

            File.WriteAllLines(Path + UsersAndAwardsFile, afterDeleted);
            return true;
        }

        public IEnumerable<LinkTable> GetAll()
        {
            return RepositoryLinkTable;
        }

        #region NotImplemented
        public LinkTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddImage(int id, byte[] img)
        {
            throw new NotImplementedException();
        }

        public bool DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, LinkTable linkTable)
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
        #endregion

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
