using LinksManager.Entities;
using System.Collections.Generic;

namespace LinksManager.BusinessLogic.Abstract
{
    public interface ILinkService
    {
        Link GetLinkById(int id);
        IEnumerable<Link> GetLinksByCategory(string categoryName);
        IEnumerable<Link> GetLinksByTitle(string title);
        IEnumerable<Link> GetLinksByDescription(string description);
    }
}
