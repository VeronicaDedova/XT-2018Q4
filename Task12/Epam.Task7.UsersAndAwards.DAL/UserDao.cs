using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.DAL
{
    public class UserDao : IRepositoryDAO<User>
    {
        private const string UsersFile = "users.txt";

        private static readonly string Path = AppContext.BaseDirectory + @"\..\usersAndAwards\";

        private static readonly Dictionary<int, User> RepositoryUsers = FileWithUsers();

        public void Add(User user)
        {
            var lastId = RepositoryUsers.Any()
                ? RepositoryUsers.Keys.Max()
                : 0;

            user.Id = ++lastId;
            RepositoryUsers.Add(user.Id, user);
            File.AppendAllLines(Path + UsersFile, new[] { user.ToString() });
        }

        public bool Update(int id, User user)
        {
            user.Id = id;
            if (!RepositoryUsers.ContainsKey(id))
            {
                return false;
            }

            RepositoryUsers[id] = user;
            var afterUpdate = RepositoryUsers.Values.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(Path + UsersFile, afterUpdate);
            return true;
        }

        public bool Delete(int id)
        {
            RepositoryUsers.Remove(id);

            var afterDelete = RepositoryUsers.Values.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(Path + UsersFile, afterDelete);
            return true;
        }

        public User GetById(int id)
        {
            if (RepositoryUsers.TryGetValue(id, out var user))
            {
                return user;
            }

            return null;
        }

        public bool TryGetId(int id)
        {
            if (RepositoryUsers.TryGetValue(id, out var user))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return RepositoryUsers.Values;
        }

        public void GiveAward(int idU, int idA)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListOfUserAwards()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsersWithAwards()
        {
            throw new NotImplementedException();
        }

        public void AddImage(int id, byte[] img)
        {
            File.WriteAllBytes(Path + @"\ImgUser\" + id, img);

            RepositoryUsers[id].Img = img;
        }

        public bool DeleteImage(int id)
        {
            File.Delete(Path + @"\ImgUser\" + id);
            return true;
        }

        private static Dictionary<int, User> FileWithUsers()
        {
            Dictionary<int, User> repositoryUsers = new Dictionary<int, User>();
            User user;

            var lines = File.ReadAllLines(Path + UsersFile);
            foreach (var line in lines)
            {
                int fid = int.Parse(line.Split(' ')[0]);
                string ffirstName = line.Split(' ')[1];
                string flastName = line.Split(' ')[2];
                string fpatronymic = line.Split(' ')[3];
                DateTime fdateOfBirth = DateTime.Parse(line.Split(' ')[4]);
                byte[] img;
                if (File.Exists(Path + @"ImgUser\" + fid))
                {
                    img = File.ReadAllBytes(Path + @"ImgUser\" + fid);
                }
                else
                {
                    img = File.ReadAllBytes(Path + @"\ImgUser\" + "default");
                }

                user = new User
                {
                    Id = fid,
                    FirstName = ffirstName,
                    LastName = flastName,
                    Patronymic = fpatronymic,
                    DateOfBirth = fdateOfBirth,
                    Img = img,
                };

                repositoryUsers.Add(int.Parse(line.Split(' ')[0]), user);
            }

            return repositoryUsers;
        }
    }
}
