using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebBlog.Entities;
using WebBlog.Site.Resources;

namespace WebBlog.Site.Areas.Admin.Models.Tag
{
    public class TagViewModel
    {
        [Required]
        [Display(ShortName = "TagName", ResourceType = typeof(Strings))]
        public string TagName { get; set; }

        public Guid TagId { get; set; }
    }
}
