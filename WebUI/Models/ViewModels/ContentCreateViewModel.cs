using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using System.Web.Mvc;

namespace WebUI.Models.ViewModels
{
    public class ContentCreateViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Название")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Категория")]
        public int CategoryID { get; set; }
        public IEnumerable<SelectListItem> CategoriesSelectList { get { return new SelectList(Categories, "ID", "Name"); } }
        public IEnumerable<Category> Categories { get; set; }
        [Required]
        [Display(Name = "MIME-тип контента")]
        public int ContentTypeID { get; set; }
        public IEnumerable<SelectListItem> ContentTypesSelectList { get { return new SelectList(ContentTypes, "ID", "Type"); } }
        public IEnumerable<ContentType> ContentTypes { get; set; }
    }
}