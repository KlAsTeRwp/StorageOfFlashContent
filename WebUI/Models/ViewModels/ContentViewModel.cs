using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models.ViewModels
{
    public class ContentViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Название")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Категория")]
        [DataType(DataType.Text)]
        public string Category { get; set; }
        [Display(Name = "MIME-тип контента")]
        [DataType(DataType.Text)]
        public string ContentType { get; set; }
        [Display(Name = "Средний рейтинг")]
        public double AverageRate { get { return Rates.Count() == 0 ? 0.00 : Rates.Average(x => x.Value); } }
        public IEnumerable<Rate> Rates { get; set; }
    }
}