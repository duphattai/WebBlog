using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebBlog.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Category()
        {
            Posts = new HashSet<Post>();
        }
    }
}
