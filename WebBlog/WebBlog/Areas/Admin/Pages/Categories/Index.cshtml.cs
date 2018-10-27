using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBlog.Entities;
using WebBlog.Service;
using WebBlog.Site.Areas.Admin.Models.Category;
using WebBlog.Site.Resources;

namespace WebBlog.Site.Areas.Admin.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public CategoryViewModel CategoryModel { get; set; }

        public IList<CategoryViewModel> Categories { get; set; }

        public IndexModel(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public IActionResult OnGet()
        {
            Categories = _mapper.Map<IList<CategoryViewModel>>(_categoryService.GetAll());
           return Page();
        }

        public IActionResult OnPostAdd()
        {
            Categories = _mapper.Map<IList<CategoryViewModel>>(_categoryService.GetAll());
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else if (_categoryService.Exist(CategoryModel.CategoryName))
            {
                ModelState.AddModelError($"{nameof(CategoryModel)}.{nameof(CategoryModel.CategoryName)}",
                    string.Format(Strings.Error_HasExisted, Strings.CategoryName));

                return Page();
            }


            _categoryService.Insert(CategoryModel.CategoryName);

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
            else if (_categoryService.Exist(CategoryModel.CategoryName, CategoryModel.CategoryId))
            {
                errors = string.Format(Strings.Error_HasExisted, Strings.CategoryName);
            }

            if (!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var entity = _mapper.Map<Category>(CategoryModel);
            _categoryService.Update(entity);

            return new OkResult();
        }


        public IActionResult OnGetDelete(Guid id)
        {
            _categoryService.Delete(id);
            return RedirectToPage();
        }
    }
}