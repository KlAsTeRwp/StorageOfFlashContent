using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models.ViewModels
{
    public class ContentEditViewModel
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
        [DataType(DataType.Custom)]
        public int CategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        [Required]
        [Display(Name = "MIME-тип контента")]
        public int ContentTypeID { get; set; }
        public IEnumerable<ContentType> ContentTypes { get; set; }
        [Display(Name = "Файл")]
        [DataType(DataType.Upload)]
        public byte[] File { get; set; }
    }
}