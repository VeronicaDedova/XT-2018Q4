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
    public class LinkTableLogic : IRepositoryLogic<LinkTable>
    {
        private readonly IRepositoryDAO<LinkTable> linkTableDao;

        public LinkTableLogic(IRepositoryDAO<LinkTable> linkTableDao)
        {
            this.linkTableDao = linkTableDao;
        }

        public void Add(LinkTable linkTable)
        {
            this.linkTableDao.Add(linkTable);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LinkTable> GetAll()
        {
            return this.linkTableDao.GetAll();
        }

        public LinkTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool TryGetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
