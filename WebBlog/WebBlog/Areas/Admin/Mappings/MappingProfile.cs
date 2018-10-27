using AutoMapper;
using WebBlog.Entities;
using WebBlog.Site.Areas.Admin.Models.Category;
using WebBlog.Site.Areas.Admin.Models.Tag;

namespace WebBlog.Site.Areas.Admin.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TagViewModel, Tag>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TagName));
            CreateMap<Tag, TagViewModel>()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CategoryViewModel, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
