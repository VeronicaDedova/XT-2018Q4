using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class AwardDao : IRepositoryDAO<Award>
    {
        private const string AwardsFile = "awards.txt";

        private static readonly string Path = AppContext.BaseDirectory + @"\..\usersAndAwards\";

        private static readonly Dictionary<int, Award> RepositoryAwards = FileWithAwards();

        public void Add(Award award)
        {
            var lastId = RepositoryAwards.Any()
                ? RepositoryAwards.Keys.Max()
                : 0;

            award.Id = ++lastId;
            RepositoryAwards.Add(award.Id, award);
            File.AppendAllLines(Path + AwardsFile, new[] { award.ToString() });
        }

        public bool Update(int id, Award award)
        {
            award.Id = id;
            if (!RepositoryAwards.ContainsKey(id))
            {
                return false;
            }

            RepositoryAwards[id] = award;
            var afterUpdate = RepositoryAwards.Values.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(Path + AwardsFile, afterUpdate);
            return true;
        }

        public bool Delete(int id)
        {
            RepositoryAwards.Remove(id);

            var afterDelete = RepositoryAwards.Values.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(Path + AwardsFile, afterDelete);
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

        public bool TryGetId(int id)
        {
            if (RepositoryAwards.TryGetValue(id, out var awards))
            {
                return true;
            }

            return false;
        }

        public void GiveAward(int idU, int idA)
        {
            throw new NotImplementedException();
        }

        public void AddImage(int id, byte[] img)
        {
            File.WriteAllBytes(Path + @"\ImgAward\" + id, img);

            RepositoryAwards[id].Img = img;
        }

        public bool DeleteImage(int id)
        {
            File.Delete(Path + @"\ImgAward\" + id);
            return true;
        }

        private static Dictionary<int, Award> FileWithAwards()
        {
            Dictionary<int, Award> repositoryAwards = new Dictionary<int, Award>();
            Award award;

            var lines = File.ReadAllLines(Path + AwardsFile);
            foreach (var line in lines)
            {
                int id = int.Parse(line.Split(' ')[0]);
                string title = line.Substring(line.IndexOf(' ') + 1);
                byte[] img;
                if (File.Exists(Path + @"ImgAward\" + id))
                {
                    img = File.ReadAllBytes(Path + @"ImgAward\" + id);
                }
                else
                {
                    img = File.ReadAllBytes(Path + @"\ImgAward\" + "default");
                }

                award = new Award
                {
                    Id = id,
                    Title = title,
                    Img = img,
                };

                repositoryAwards.Add(int.Parse(line.Split(' ')[0]), award);
            }

            return repositoryAwards;
        }
    }
}
