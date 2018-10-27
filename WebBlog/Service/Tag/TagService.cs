using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Entities;
using WebBlog.Repository;

namespace WebBlog.Service
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task Delete(Guid entityId)
        {
            await _tagRepository.Delete(_tagRepository.FindById(entityId));
        }

        public bool Exist(string tagName)
        {
            return _tagRepository.Exists(x => x.Name == tagName);
        }

        public bool Exist(string tagName, Guid excludeId)
        {
            return _tagRepository.Exists(x => x.Name == tagName && x.TagId != excludeId);

        }

        public Tag FindById(Guid Id)
        {
            return _tagRepository.FindById(Id);
        }

        public IList<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public Tag Insert(string tagName)
        {
            Tag entity = new Tag
            {
                Name = tagName
            };

            return _tagRepository.Insert(entity);
        }

        public Tag Update(Tag entity)
        {
            return _tagRepository.Update(entity);
        }
    }
}
