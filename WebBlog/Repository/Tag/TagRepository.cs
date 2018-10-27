using WebBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using WebBlog.Entities.Context;
using System.Linq;

namespace WebBlog.Repository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(BlogEntities entities) : base(entities)
        {
        }

        public override Tag Update(Tag entity)
        {
            _entities.Entry(entity).Property(p => p.Name).IsModified = true;
            return base.Update(entity);
        }
    }
}
