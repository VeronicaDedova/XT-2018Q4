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
    public class AwardDao : IRepositoryDAO<Award>
    {
        private const string AwardsFile = "awards.txt";
        private static readonly string Path = Environment.CurrentDirectory + @"\usersAndAwards\" + AwardsFile;

        private static readonly Dictionary<int, Award> RepositoryAwards = FileWithAwards();

        public void Add(Award award)
        {
            var lastId = RepositoryAwards.Any()
                ? RepositoryAwards.Keys.Max()
                : 0;

            award.Id = ++lastId;
            RepositoryAwards.Add(award.Id, award);
            File.AppendAllLines(Path, new[] { award.ToString() });
        }

        public bool Delete(int id)
        {
            RepositoryAwards.Remove(id);

            var afterDelet = RepositoryAwards.Values.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(Path, afterDelet);
            return true;
        }

        public IEnumerable<Award> GetAll()
        {
            return RepositoryAwards.Values;
        }

        public Award GetById(int id)
        {
            if (RepositoryAwards.TryGetValue(id, out var awards))
            {
                return awards;
            }

            return null;
        }

        private static Dictionary<int, Award> FileWithAwards()
        {
            Dictionary<int, Award> repositoryAwards = new Dictionary<int, Award>();
            Award award;

            var lines = File.ReadAllLines(Path);
            foreach (var line in lines)
            {
                string title = line.Split(' ')[1];
                
                award = new Award
                {
                    Title = title,
                };

                repositoryAwards.Add(int.Parse(line.Split(' ')[0]), award);
            }

            return repositoryAwards;
        }
    }
}
