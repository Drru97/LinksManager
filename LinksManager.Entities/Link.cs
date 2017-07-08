using System.ComponentModel.DataAnnotations;

namespace LinksManager.Entities
{
    public class Link
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
