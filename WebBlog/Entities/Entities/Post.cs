using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebBlog.Entities.Enum;

namespace WebBlog.Entities
{
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime PostedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public PostStatus Status { get; set; }

     
        public Guid UserId { get; set; }
        [ForeignKey(nameof(Post.UserId))]
        public virtual User User { get; set; }


        public Guid BlogId { get; set; }
        [ForeignKey(nameof(Post.BlogId))]
        public virtual Blog Blog { get; set; }

        public virtual ICollection<PostTag> Tags { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(Post.CategoryId))]
        public virtual Category Category { get; set; }

        public Post()
        {
            Tags = new HashSet<PostTag>();
        }
    }
}
