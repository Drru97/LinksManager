using System;
using System.Collections.Generic;
using System.Data.Entity;
using LinksManager.DataAccess.Abstract;
using LinksManager.Entities;
// ReSharper disable InconsistentNaming

namespace LinksManager.DataAccess.Concrete
{
    public class EFLinkCategoryRepository : ILinkCategoryRepository
    {
        private readonly LinkContext _linkContext;
        private bool disposed;

        public EFLinkCategoryRepository()
        {
            _linkContext = new LinkContext();
        }

        public IEnumerable<LinkCategory> GetAll()
        {
            return _linkContext.Categories;
        }

        public LinkCategory Get(int id)
        {
            return _linkContext.Categories.Find(id);
        }

        public void Add(LinkCategory item)
        {
            _linkContext.Categories.Add(item);
        }

        public void Update(LinkCategory item)
        {
            _linkContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var category = _linkContext.Categories.Find(id);

            if (category != null)
            {
                _linkContext.Categories.Remove(category);
            }
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
