using System.Data.Entity;

namespace LinksManager.Entities
{
    public class LinkContext : DbContext
    {
        public LinkContext() : base("LinkConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LinkContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
