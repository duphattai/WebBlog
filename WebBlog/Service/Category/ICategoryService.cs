using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;

namespace WebBlog.Service
{
    public interface ICategoryService
    {
        Category Insert(string categoryName);
        bool Exist(string categoryName);
        bool Exist(string categoryName, Guid excludeId);
        Category Update(Category entity);
        Task Delete(Guid entityId);
        Category FindById(Guid Id);
        IList<Category> GetAll();
    }
}
