using System.Collections.Generic;

namespace LinksManager.Entities
{
    public class LinkCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual IList<Link> Links { get; set; }
    }
}
