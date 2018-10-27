using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;
using WebBlog.Entities.Context;

namespace WebBlog.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogEntities entities) : base(entities)
        {
        }
    }
}
