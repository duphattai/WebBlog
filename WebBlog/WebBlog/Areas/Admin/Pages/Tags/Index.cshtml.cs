using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using WebBlog.Entities;
using WebBlog.Service;
using WebBlog.Site.Areas.Admin.Models.Tag;
using WebBlog.Site.Resources;

namespace WebBlog.Site.Areas.Admin.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        [BindProperty]
        public TagViewModel TagModel { get; set; }
        public IList<TagViewModel> Tags { get; set; }

        public IndexModel(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            Tags = _mapper.Map<IList<TagViewModel>>(_tagService.GetAll());
            return Page();
        }

        public IActionResult OnPostAdd()
        {
            Tags = _mapper.Map<IList<TagViewModel>>(_tagService.GetAll());
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else if (_tagService.Exist(TagModel.TagName))
            {
                ModelState.AddModelError($"{nameof(TagModel)}.{nameof(TagModel.TagName)}", 
                    string.Format(Strings.Error_HasExisted, Strings.TagName));

                return Page();
            }


            _tagService.Insert(TagModel.TagName);

            return RedirectToPage("Index");
        }

        [HttpPost]
        public IActionResult OnPostEdit()
        {
            string errors = string.Empty;
            if (!ModelState.IsValid)
            {
                errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            }
            else if (_tagService.Exist(TagModel.TagName, TagModel.TagId))
            {
                errors = string.Format(Strings.Error_HasExisted, Strings.TagName);
            }

            if (!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var entity = _mapper.Map<Tag>(TagModel);
            _tagService.Update(entity);

            return new OkResult();
        }

        public IActionResult OnGetDelete(Guid id)
        {
            _tagService.Delete(id);
            return RedirectToPage();
        }
    }
}