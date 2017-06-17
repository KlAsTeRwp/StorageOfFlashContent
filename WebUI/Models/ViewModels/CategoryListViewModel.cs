using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models.ViewModels
{
    public class CategoryListViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Название")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}