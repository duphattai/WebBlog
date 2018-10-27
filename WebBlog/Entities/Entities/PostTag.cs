using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebBlog.Entities
{
    public class PostTag
    {
        public Guid PostId { get; set; }
        [ForeignKey(nameof(PostTag.PostId))]
        public virtual Post Post { get; set; }

     
        public Guid TagId { get; set; }

        [ForeignKey(nameof(PostTag.TagId))]
        public virtual Tag Tag { get; set; }
    }
}
