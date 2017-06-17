using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Domain.Entities
{
    //model of file Type
    public class ContentType
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //type, etc.'audio/mpeg'
        [Required]
        [Display(Name = "MIME-тип файла")]
        [DataType(DataType.Text)]
        public string Type { get; set; }
        //extensions of content
        [Required]
        [Display(Name = "Расширения")]
        [DataType(DataType.Text)]
        public string Extensions { get; set; }
        //navigation property for foreign table of class Content
        //relationship betwenn Content and ContentType is many-to-one
        public virtual ICollection<Content> Contents { get; set; }
    }
}
