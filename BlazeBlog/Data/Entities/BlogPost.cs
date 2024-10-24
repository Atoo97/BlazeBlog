using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazeBlog.Data.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Title { get; set; }

        [Required, MaxLength(150)]
        public string Slug { get; set; }

        public int CategoryId { get; set; }

        public int UsreId { get; set; }

        [Required, MaxLength(250)]
        public string Introduction { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool isPublished { get; set; }

        public DateTime? PublishedOn { get; set; } //only have value when isPublished == true

        public DateTime? ModifedOn { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
