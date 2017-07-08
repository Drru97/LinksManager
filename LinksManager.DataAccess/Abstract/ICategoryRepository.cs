using LinksManager.Entities;

namespace LinksManager.DataAccess.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category Get(int id);
    }
}
