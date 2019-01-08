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

        public void Delete(int id)
        {
            this.awardDao.Delete(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return this.awardDao.GetAll();
        }

        public Award GetById(int id)
        {
            return this.awardDao.GetById(id);
        }
    }
}
