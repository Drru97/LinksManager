using System.Linq;
using LinksManager.DataAccess.Abstract;
using LinksManager.Entities;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace LinksManager.DataAccess.Concrete
{
    public class EFCategoryRepository : GenericRepository<LinkContext, Category>, ICategoryRepository
    {
        public Category Get(int id)
        {
            return Context.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
