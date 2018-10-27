using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;
using WebBlog.Entities.Context;

namespace WebBlog.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(BlogEntities entities) : base(entities)
        {
        }
    }
}
