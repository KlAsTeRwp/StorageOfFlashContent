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
    public class RateEditViewModel
    {
        [HiddenInput]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите значение!")]
        [Range(1, 10, ErrorMessage = "Вне диапазона допустимых значений")]
        [Display(Name = "Оценка")]
        public int Value { get; set; }
        [Required]
        [Display(Name = "Отзыв")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Объект отзыва")]
        public int ContentID { get; set; }
        public IEnumerable<SelectListItem> ContentsSelectList { get { return new SelectList(Contents, "ID", "Name"); } }
        public IEnumerable<Content> Contents { get; set; }
    }
}