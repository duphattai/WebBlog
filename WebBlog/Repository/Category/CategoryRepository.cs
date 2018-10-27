using WebBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using WebBlog.Entities.Context;

namespace WebBlog.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogEntities entities) : base(entities)
        {
        }
    }
}
