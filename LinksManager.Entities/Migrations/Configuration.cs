using System.Collections.Generic;
using System.Linq;

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
            context.Categories.AddRange(new List<Category>
            {
                new Category {Name = "Web search"},
                new Category {Name = "Social"},
                new Category {Name = "News"},
                new Category {Name = "Weather"}
            });
            context.SaveChanges();

            context.Links.AddRange(new List<Link>
            {
                new Link
                {
                    Title = "Google",
                    Url = "https://google.com",
                    Description = "Just Google it!",
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Web search")
                },
                new Link
                {
                    Title = "Facebook",
                    Url = "https://facebook.com",
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Social")
                },
                new Link
                {
                    Title = "Github",
                    Url = "https://github.com",
                    Category = context.Categories.FirstOrDefault(c => c.Name == "News")
                },
                new Link
                {
                    Title = "Gismeteo",
                    Url = "http://gismeteo.ua",
                    Category = context.Categories.FirstOrDefault(c => c.Name == "News")
                }
            });
            context.SaveChanges();
        }
    }
}
