using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebBlog.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public Guid Salt { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

  
        public Guid BlogId { get; set; }

        [ForeignKey(nameof(User.BlogId))]
        public virtual Blog Blog { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new HashSet<Post>();
        }
    }
}
