using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //model of rate of content
    public class Rate
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //value of rate
        public int Value { get; set; }
        //description of rate
        public string Description { get; set; }
        //navigation propery
        //relationship between Content and Rate: zero or one-to-one
        public virtual Content Content { get; set; }
    }
}
