using System;
using System.Collections.Generic;
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

        #region NotImplemented
        public void AddImage(int id, byte[] img)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            return this.linkTableDao.Delete(id);
        }

        public bool DeleteImage(int id)
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

        public void Update(int id, LinkTable item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
