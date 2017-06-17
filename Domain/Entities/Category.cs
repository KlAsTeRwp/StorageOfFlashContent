using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Domain.Entities
{
    //model of info about category
    public class Category
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //name of category
        [Required]
        [Display(Name = "Название")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        //description of category
        [Required]
        [Display(Name = "Описание категории")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //navigation property
        //relationship between Content and Category: one-to-many
        public virtual ICollection<Content> Contents { get; set; }
    }
}
