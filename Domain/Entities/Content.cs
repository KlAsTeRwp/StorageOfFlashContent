using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public byte[] Data { get; set; }
        //navigation properties
        //foreign keys
        public int? ContentDescriptionID { get; set; }
        public int? CategoryID { get; set; }
        public int ContentTypeID { get; set; }
        //relationship between Content and ContentDescription: one-to-one
        public virtual ContentDescription ContentDescription { get; set; }
        //realtionship between Content and ContentDescription: one-to-one
        public virtual Category Category { get; set; }
        //relationship between Content and Rate: one-to-one
        public virtual Rate Rate { get; set; }
        //relationship between Content and ContentType: many-to-one
        public virtual ContentType ContentType { get; set; }
    }
}