using System.Data.Entity;
using LinksManager.Entities.Migrations;

namespace LinksManager.Entities
{
    class DatabaseInitializer : CreateDatabaseIfNotExists<LinkContext>
    {
        protected override void Seed(LinkContext context)
        {
            base.Seed(context);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LinkContext, Configuration>());
        }
    }
}
