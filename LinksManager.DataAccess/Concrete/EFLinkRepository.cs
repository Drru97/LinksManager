using System.Linq;
using LinksManager.DataAccess.Abstract;
using LinksManager.Entities;
// ReSharper disable InconsistentNaming

namespace LinksManager.DataAccess.Concrete
{
    public class EFLinkRepository : GenericRepository<LinkContext, Link>, ILinkRepository
    {
        public Link Get(int id)
        {
            return Context.Links.FirstOrDefault(l => l.Id == id);
        }
    }
}
