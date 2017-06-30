using System;
using System.Collections.Generic;
using System.Data.Entity;
using LinksManager.DataAccess.Abstract;
using LinksManager.Entities;

// ReSharper disable InconsistentNaming

namespace LinksManager.DataAccess.Concrete
{
    public class EFLinkRepository : ILinkRepository
    {
        private readonly LinkContext _linkContext;
        private bool disposed;

        public EFLinkRepository()
        {
            _linkContext = new LinkContext();
        }

        public void Add(Link item)
        {
            _linkContext.Links.Add(item);
        }

        public void Delete(int id)
        {
            var link = _linkContext.Links.Find(id);

            if (link != null)
            {
                _linkContext.Links.Remove(link);
            }
        }

        public Link Get(int id)
        {
            return _linkContext.Links.Find(id);
        }

        public IEnumerable<Link> GetAll()
        {
            return _linkContext.Links;
        }

        public void Update(Link item)
        {
            _linkContext.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _linkContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _linkContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
