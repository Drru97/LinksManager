using LinksManager.Entities;

namespace LinksManager.DataAccess.Abstract
{
    public interface ILinkRepository : IGenericRepository<Link>
    {
        Link Get(int id);
    }
}
