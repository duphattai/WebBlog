using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebBlog.Entities
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Email { get; set; }
        public string Url { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CommentedDate { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
