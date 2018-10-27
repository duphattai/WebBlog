using WebBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBlog.Repository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag Update(Tag entity);
    }
}
