using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.UsersAndAwards.BLL.Interface;
using Epam.Task7.UsersAndAwards.DAL.Interface;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.BLL
{
    public class AwardLogic : IRepositoryLogic<Award>
    {
        private readonly IRepositoryDAO<Award> awardDao;

        public AwardLogic(IRepositoryDAO<Award> awardDao)
        {
            this.awardDao = awardDao;
        }

        public void Add(Award award)
        {
            this.awardDao.Add(award);
        }

        public void AddImage(int id, byte[] img)
        {
            this.awardDao.AddImage(id, img);
        }

        public bool Delete(int id)
        {
            return this.awardDao.Delete(id);
        }

        public bool DeleteImage(int id)
        {
            return this.awardDao.DeleteImage(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return this.awardDao.GetAll();
        }

        public Award GetById(int id)
        {
            return this.awardDao.GetById(id);
        }

        public bool TryGetId(int id)
        {
            return this.awardDao.TryGetId(id);
        }

        public void Update(int id, Award award)
        {
            this.awardDao.Update(id, award);
        }
    }
}
