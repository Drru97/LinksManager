using LinksManager.Entities;
using System.Collections.Generic;

namespace LinksManager.BusinessLogic.Abstract
{
    public interface ILinkService
    {
        Link GetLinkById(int id);
        IEnumerable<Link> GetAll();
        IEnumerable<Link> GetLinksByCategory(string categoryName);
        IEnumerable<Link> GetLinksByTitle(string title);
        IEnumerable<Link> GetLinksByDescription(string description);

        bool AddLink(Link link);
        bool EditLink(int id, Link link);
        bool DeleteLink(int id);
    }
}
