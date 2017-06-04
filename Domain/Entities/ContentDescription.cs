using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //model of content description
    //relation type betwenn content and content description: one-to-one
    public class ContentDescription
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //description
        public string Description { get; set; }
        //reference to foreign key
        //relationship between Content and ContentDescprion: one-to-one
        public virtual Content Content { get; set; }
    }
}
