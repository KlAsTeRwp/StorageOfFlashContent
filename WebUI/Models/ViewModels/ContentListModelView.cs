using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models.ViewModels
{
    public class ContentListViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Название")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Категория")]
        [DataType(DataType.Text)]
        public string Category { get; set; }
        [Required]
        [Display(Name = "MIME-тип контента")]
        [DataType(DataType.Text)]
        public string ContentType { get; set; }
        [Required]
        [Display(Name = "Средняя оценка")]
        public double AverageRate { get; set; }
    }
}