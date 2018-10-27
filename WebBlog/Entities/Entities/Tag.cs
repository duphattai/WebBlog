using System;
using System.Collections.Generic;
using System.Text;

namespace WebBlog.Entities
{
    public class Tag
    {
        public Guid TagId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PostTag> Posts { get; set; }

        public Tag()
        {
            Posts = new HashSet<PostTag>();
        }
    }
}
