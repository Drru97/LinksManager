using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinksManager.Entities
{
    public sealed class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<Link> Links { get; set; } = new List<Link>();
    }
}
