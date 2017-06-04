using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //model of info about category
    public class Category
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //description of category
        public string Description { get; set; }
        //reference to foreign key
        //relationship between Content and Category: one-to-one
        public virtual Content Content { get; set; }
    }
}
