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
        //foreign key
        public int? ContentDescriptionID { get; set; }
        //navigation property
        //relationship between ContentDescprion and Content: zero or one-to-one
        public virtual Content Content { get; set; }
    }
}
