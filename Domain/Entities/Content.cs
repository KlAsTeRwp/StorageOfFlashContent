using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Domain.Entities
{
    //model of content
    public class Content
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //array of bytes
        //here will storage file
        [Required]
        public byte[] Data { get; set; }
        //navigation properties
        //relationship between Content and ContentDescription: one-to-one
        public virtual ContentDescription ContentDescription { get; set; }
        //realtionship between Content and ContentDescription: one-to-one
        public virtual Category Category { get; set; }
        //relationship between Content and ContentType: many-to-one
        [Required]
        public virtual ContentType ContentType { get; set; }
        //relationship between Content and Rate: one-to-many
        public virtual IEnumerable<Rate> Rate { get; set; }
    }
}