using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebBlog.Site.Resources;

namespace WebBlog.Site.Areas.Admin.Models.Category
{
    public class CategoryViewModel
    {
        [Required]
        [Display(ShortName = "CategoryName", ResourceType = typeof(Strings))]
        public string CategoryName { get; set; }

        public Guid CategoryId { get; set; }
    }
}
