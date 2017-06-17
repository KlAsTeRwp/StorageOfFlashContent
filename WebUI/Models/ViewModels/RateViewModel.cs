using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models.ViewModels
{
    public class RateViewModel
    {
        public int ID { get; set; }
        //value of rate
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите значение!")]
        [Range(1, 10, ErrorMessage = "Вне диапазона допустимых значений")]
        [Display(Name = "Оценка")]
        [UIHint("Decimal")]
        public int Value { get; set; }
        //description of rate
        [Required]
        [Display(Name = "Отзыв")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Объект отзыва")]
        public string Name { get; set; }
    }
}