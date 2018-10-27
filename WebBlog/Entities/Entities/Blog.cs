using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebBlog.Entities
{
    public class Blog
    {
        [Key]
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool AllowsComments { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
