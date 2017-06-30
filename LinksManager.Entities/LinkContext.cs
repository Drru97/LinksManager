using System.Data.Entity;

namespace LinksManager.Entities
{
    public class LinkContext : DbContext
    {
        public LinkContext() : base("LinkConnection") { }

        public DbSet<LinkCategory> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}
