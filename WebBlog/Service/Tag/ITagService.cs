using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;

namespace WebBlog.Service
{
    public interface ITagService
    {
        Tag Insert(string tagName);
        bool Exist(string tagName);
        bool Exist(string tagName, Guid excludeId);
        Tag Update(Tag entity);
        Task Delete(Guid entityId);
        Tag FindById(Guid Id);
        IList<Tag> GetAll();
    }
}
