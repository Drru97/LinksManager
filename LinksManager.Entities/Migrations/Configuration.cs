namespace LinksManager.Entities.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LinkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LinksManager.Entities.LinkContext";
        }

        protected override void Seed(LinkContext context)
        {
            // TODO: Add some initial data
        }
    }
}
