using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;
using WebBlog.Repository;

namespace WebBlog.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Delete(Guid entityId)
        {
            await _categoryRepository.Delete(_categoryRepository.FindById(entityId));
        }

        public bool Exist(string categoryName)
        {
            return _categoryRepository.Exists(x => x.Name == categoryName);
        }

        public bool Exist(string categoryName, Guid excludeId)
        {
            return _categoryRepository.Exists(x => x.Name == categoryName && x.CategoryId != excludeId);

        }

        public Category FindById(Guid Id)
        {
            return _categoryRepository.FindById(Id);
        }

        public IList<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category Insert(string categoryName)
        {
            Category entity = new Category
            {
                Name = categoryName
            };

            return _categoryRepository.Insert(entity);
        }

        public Category Update(Category entity)
        {
            return _categoryRepository.Update(entity);
        }
    }
}
