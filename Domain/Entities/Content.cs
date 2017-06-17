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
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Название:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        //array of bytes
        //here will storage file
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Файл")]
        public byte[] Data { get; set; }
        //Description of Content
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        //navigation properties
        //realtionship between Content and Category: one-to-one
        public virtual Category Category { get; set; }
        //relationship between Content and ContentType: many-to-one
        public virtual ContentType ContentType { get; set; }
        //relationship between Content and Rate: one-to-many
        public virtual ICollection<Rate> Rates { get; set; }
        //foreign keys
        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        [Required]
        [ForeignKey("ContentType")]
        public int ContentTypeID { get; set; }
    }
}