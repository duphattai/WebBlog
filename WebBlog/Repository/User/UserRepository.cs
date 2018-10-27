using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;
using WebBlog.Entities.Context;

namespace WebBlog.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogEntities entities) : base(entities)
        {
        }
    }
}
