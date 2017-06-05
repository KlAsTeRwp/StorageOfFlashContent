using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Type { get; set; }
        //extensions of content
        [Required]
        public string Extensions { get; set; }
    }
}
